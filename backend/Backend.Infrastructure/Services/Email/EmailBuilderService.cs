using Backend.Application.Interfaces.Services;

namespace Backend.Infrastructure.Services.Email;

public class EmailBuilderService : IEmailBuilderService
{
    public string BuildAccountVerificationEmail(string username, string verificationUrl)
    { 
        const string title = """
                             <p style="font-weight: bold; font-size: 20px; color: #15161d">
                               Confirm your account
                             </p>
                             """;
        
        var body = $"""

                   <p style="color: #15161d; font-size: 16px; margin: 20px 0">
                     Hello, {username}!<br />Thank you for signing up. Please verify your
                     account by clicking the button below:
                   </p>

                   <a
                     href="{verificationUrl}"
                     style="
                       display: inline-block;
                       padding: 12px 24px;
                       background-color: #e02b4a;
                       color: #fff;
                       text-decoration: none;
                       border-radius: 5px;
                       font-family: 'Montserrat', Arial, sans-serif;
                     "
                   >
                     Verify My Account
                   </a>

                   """;

        const string footer = """

                              <p style="font-size: 14px; font-weight: 600; color: #1e1f29">
                                This email was sent by DIGITE<span style="color: #e02b4a">X</span>. If you
                                did not sign up, please ignore this message.
                              </p>

                              """;

        return BuildEmail(title, body, footer);
    }

    public string BuildPasswordResetEmail(string username, string passwordResetUrl)
    {
        const string title = """
                           <p style="font-weight: bold; font-size: 20px; color: #15161d">
                             Reset Your Password
                           </p>
                           """;

        var body = $"""
                    <p style="color: #15161d; font-size: 16px; margin: 20px 0">
                      Hello, {username}!<br />
                      We received a request to reset your password. Click the button below to set a new password:
                    </p>

                    <a
                      href="{passwordResetUrl}"
                      style="
                        display: inline-block;
                        padding: 12px 24px;
                        background-color: #e02b4a;
                        color: #fff;
                        text-decoration: none;
                        border-radius: 5px;
                        font-family: 'Montserrat', Arial, sans-serif;
                      "
                    >
                      Reset Password
                    </a>
                    """;

        const string footer = """
                              <p style="font-size: 14px; font-weight: 600; color: #1e1f29; margin-top: 20px;">
                                This email was sent by DIGITE<span style="color: #e02b4a">X</span>. If you did not request a password reset, please ignore this message.
                              </p>
                              """;

        return BuildEmail(title, body, footer);
    }
    
    private static string BuildEmail(string title, string body, string footer)
    {
        return $"""

                <html lang="en">
                  <body style="font-family: 'Montserrat', Arial, sans-serif">
                    <p
                      style="
                        font-weight: bold;
                        font-size: 30px;
                        color: #1e1f29;
                        text-transform: uppercase;
                      "
                    >
                      digite<span style="color: crimson">x</span>
                    </p>

                    <p style="font-weight: bold; font-size: 20px; color: #15161d">
                      {title}
                    </p>

                    <hr style="border: none; border-top: 1px solid #ddd; margin: 20px 0" />

                    {body}

                    <hr style="border: none; border-top: 1px solid #ddd; margin: 20px 0" />

                    {footer}
                  </body>
                </html>

                """;
    }
}