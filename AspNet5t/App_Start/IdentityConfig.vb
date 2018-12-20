Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports S5T
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports S5T.Web.Security

Public Class EmailService
    Implements IIdentityMessageService
    Public Function SendAsync(message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
        ' Plug in your email service here to send an email.
        Return Task.FromResult(0)
    End Function
End Class

Public Class SmsService
    Implements IIdentityMessageService
    Public Function SendAsync(message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
        ' Plug in your SMS service here to send a text message.
        Return Task.FromResult(0)
    End Function
End Class

' Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
Public Class ApplicationUserManager
    Inherits UserManager(Of IdUser)
    Public Sub New(store As IUserStore(Of IdUser))
        MyBase.New(store)
    End Sub

    Public Shared Function Create(options As IdentityFactoryOptions(Of ApplicationUserManager), context As IOwinContext) As ApplicationUserManager
        Dim manager = New ApplicationUserManager(New UserStore())
        ' Configure validation logic for usernames
        manager.UserValidator = New UserValidator(Of idUser)(manager) With {
          .AllowOnlyAlphanumericUserNames = False,
          .RequireUniqueEmail = True
        }

        ' Configure validation logic for passwords
        manager.PasswordValidator = New PasswordValidator() With {
          .RequiredLength = 1,
          .RequireNonLetterOrDigit = False,
          .RequireDigit = False,
          .RequireLowercase = False,
          .RequireUppercase = False
        }
        ' Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user. 
        ' You can write your own provider and plug in here.
        manager.RegisterTwoFactorProvider("Phone Code", New PhoneNumberTokenProvider(Of idUser)() With {
          .MessageFormat = "Your security code is {0}"
        })
        manager.RegisterTwoFactorProvider("Email Code", New EmailTokenProvider(Of idUser)() With {
          .Subject = "Security Code",
          .BodyFormat = "Your security code is {0}"
        })

        ' Configure user lockout defaults
        manager.UserLockoutEnabledByDefault = True
        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5)
        manager.MaxFailedAccessAttemptsBeforeLockout = 5

        manager.EmailService = New EmailService()
        manager.SmsService = New SmsService()
        Dim dataProtectionProvider = options.DataProtectionProvider
        If dataProtectionProvider IsNot Nothing Then
            manager.UserTokenProvider = New DataProtectorTokenProvider(Of idUser)(dataProtectionProvider.Create("ASP.NET Identity"))
        End If
        Return manager
    End Function
End Class

Public Class ApplicationSignInManager
    Inherits SignInManager(Of idUser, String)
    Public Sub New(userManager As ApplicationUserManager, authenticationManager As IAuthenticationManager)
        MyBase.New(userManager, authenticationManager)
    End Sub

    Public Overrides Function CreateUserIdentityAsync(user As IdUser) As Task(Of ClaimsIdentity)
        Return UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie)
    End Function

    Public Shared Function Create(options As IdentityFactoryOptions(Of ApplicationSignInManager), context As IOwinContext) As ApplicationSignInManager
        Return New ApplicationSignInManager(context.GetUserManager(Of ApplicationUserManager)(), context.Authentication)
    End Function
End Class
