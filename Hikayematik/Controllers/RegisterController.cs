using Hikayematik.Dto;
using Hikayematik.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

namespace Hikayematik.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            Random random = new Random();
            int code = 0;
            code = random.Next(100000, 1000000);
            AppUser appuser = new AppUser()
            {
                FirstName = appUserRegisterDto.FirstName,
                LastName = appUserRegisterDto.LastName,
                City = appUserRegisterDto.City,
                UserName = appUserRegisterDto.UserName,
                Email = appUserRegisterDto.Email,
                ConfirmCode = code,
            };
            
            var result = await _userManager.CreateAsync(appuser, appUserRegisterDto.Password);
            if (result.Succeeded)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Hikayematik Uygulaması",
                    "seyhanyandik@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", appuser.Email);
                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Kaydınız Başarılı Bir Şekilde Gerçekleşti."+code;
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "Hikayematik Uygulaması";
                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false); //587 nolu portu kullanıyor
                client.Authenticate("seyhanyandik@gmail.com", "mtud sqwu xufl dqze");
                client.Send(mimeMessage);
                client.Disconnect(true);
                TempData["Mail"] = appUserRegisterDto.Email;
                return RedirectToAction("Index","ConfirmMail");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
