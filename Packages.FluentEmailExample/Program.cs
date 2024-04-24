using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;

string fromEmail = "please enter your email."; // test.from@gmail.com
string toEmail = "please enter your email."; // test.to@gmail.com
Console.Write("Subject : "); // "hows it going sann"
string subject = Console.ReadLine()!;

Console.Write("Body : "); // "yo sann, long time no see!"
string body = Console.ReadLine()!;

var serviceCollection = new ServiceCollection();
serviceCollection
    .AddFluentEmail(fromEmail)
    .AddSmtpSender("smtp.gmail.com", 587, fromEmail, "Email App Password");
// Email App Pasword
// https://support.google.com/accounts/answer/185833
// https://myaccount.google.com/apppasswords

var services = serviceCollection.BuildServiceProvider();

var _fluentEmail = services.GetRequiredService<IFluentEmail>();

var response = await _fluentEmail
    .To(toEmail)
    .Subject(subject)
    .Body(body)
    .SendAsync();

Console.WriteLine("Message was sent => " + response.Successful);
Console.ReadLine();
