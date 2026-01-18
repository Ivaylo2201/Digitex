using Backend.Application.Interfaces.Services;

namespace Backend.Infrastructure.Services;

public class EmailBuilderService : IEmailBuilderService
{
    public string BuildAccountVerificationEmail(string username, string verificationUrl)
    { 
        var body = $"""
                         <p style="color: #15161d; font-size: 16px; line-height: 1.6">
                           Hello, <strong>{username}</strong><br />
                           Thank you for signing up. Please verify your account by clicking the button below.
                         </p>
                         
                         <div style="margin: 30px 0">
                           <a
                             href="{verificationUrl}"
                             style="
                               display: inline-block;
                               padding: 12px 30px;
                               background-color: #e02b4a;
                               color: white;
                               text-decoration: none;
                               border-radius: 6px;
                               font-size: 16px;
                               font-weight: 600;
                               border: 1px solid #d62441;
                             "
                           >
                             Verify My Account
                           </a>
                         </div>
                         
                         <p style="font-size: 13px; color: #555; line-height: 1.5">
                             For security reasons, this verification link will expire in 24 hours. If you did
                             not request account verification, no action is required.
                         </p>
                    
                    """;
      
      
        return BuildEmail("Verify Your Account", body);
    }

    public string BuildPasswordResetEmail(string username, string passwordResetUrl)
    {
        var body = $"""
                         <p style="color: #15161d; font-size: 16px; line-height: 1.6">
                           Hello, <strong>{username}</strong><br />
                           We received a request to reset your password. Click the button below to
                           choose a new one.
                         </p>
                         
                         <div style="margin: 30px 0">
                           <a
                             href="{passwordResetUrl}"
                             style="
                               display: inline-block;
                               padding: 12px 30px;
                               background-color: #e02b4a;
                               color: white;
                               text-decoration: none;
                               border-radius: 6px;
                               font-size: 16px;
                               font-weight: 600;
                               border: 1px solid #d62441;
                             "
                           >
                             Reset Password
                           </a>
                         </div>
                         
                          <p style="font-size: 13px; color: #555; line-height: 1.5">
                            For security reasons, this link will expire in 30 minutes. If you did
                            not request a password reset, no action is required.
                          </p>
                    """;

        return BuildEmail("Reset Your Password", body);
    }
    
    private static string BuildEmail(string title, string body)
    {
        return $"""

                 <html lang="en">
                   <body
                     style="
                       font-family: 'Montserrat', Arial, sans-serif;
                       background-color: #f2f2f2;
                       padding: 40px 0;
                     "
                   >
                     <div
                       style="
                         max-width: 600px;
                         margin: 0 auto;
                         background-color: #fff;
                         padding: 32px;
                         border-radius: 10px;
                         box-shadow: 0 6px 18px rgba(0, 0, 0, 0.08);
                       "
                     >
                       <p
                         style="
                           font-weight: bold;
                           font-size: 32px;
                           color: #1e1f29;
                           letter-spacing: 1px;
                           margin: 0;
                           text-transform: uppercase;
                         "
                       >
                         digite<span style="color: crimson">x</span>
                       </p>
                 
                       <hr
                         style="
                           border: none;
                           height: 3px;
                           width: 60px;
                           background-color: #e02b4a;
                           margin: 16px 0 24px;
                         "
                       />
                 
                       <p
                         style="
                           font-weight: 600;
                           font-size: 25px;
                           color: #1e1f29;
                           margin-bottom: 20px;
                         "
                       >
                         {title}
                       </p>
                 
                       <div>
                         {body}
                       </div>
                 
                       <div style="text-align: center; margin-top: 32px;">
                         <hr
                           style="
                             border: none;
                             border-top: 1px solid #eee;
                             margin: 24px auto;
                             width: 100%;
                           "
                         />
                         <p style="font-size: 13px; color: #666; line-height: 1.5; margin: 8px 0 0;">
                           This email was sent by
                           <strong style="font-weight: bold">
                             <span style="color: #1e1f29">DIGITE</span><span style="color: #e02b4a">X</span>
                           </strong>
                           <br />
                           Need help? Contact
                           <a
                             href="mailto:support@digitex.com"
                             style="color: #e02b4a; text-decoration: none; font-weight: 600"
                             >support@digitex.com</a
                           >
                         </p>
                       </div>
                     </div>
                   </body>
                 </html>

                 """;
    }
}