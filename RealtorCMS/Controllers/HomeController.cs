using Microsoft.AspNet.Identity;
using RealtorCMS.Models;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace RealtorCMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult About(EnquiryViewModel enquiry)
        {
            if (ModelState.IsValid)
            {
                MailMessage msg = new MailMessage();
                msg.To.Add("email@yahoo.com");
                msg.Subject = "New Message from AgentCMS Management";
                msg.From = new MailAddress(enquiry.Email.ToString(), enquiry.Email.ToString());
                msg.Body = enquiry.Message.ToString() + " | " + enquiry.FirstName.ToString() + " | " + enquiry.Phone.ToString();
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("username@gmail.com", "password");
                    smtp.EnableSsl = true;
                    smtp.Send(msg);
                }

                //send mail
                //redirect to thank you page
            }
            return View();
        }

        public ActionResult Blog(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (id == null)
                {
                    var blogs = context.Blogs.OrderByDescending(x => x.CreationDate).ToList();
                    return View(blogs);
                }

                var blog = context.Blogs.Where(x => x.Id == id).ToList();
                if (blog != null)
                {
                    return View(blog);
                }
                else
                {
                    //Redirect to no such page found error page
                    return HttpNotFound();
                }
            }
        }

        public ActionResult Management()
        {
            return View();
        }
        public ActionResult Sell()
        {
            return View();
        }

        public ActionResult Buy()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var properties = context.Properties.OrderByDescending(x => x.CreateDate).ToList();
                return View(properties);
            }
        }

        [HttpPost]
        public ActionResult Buy(SearchFilter filter)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var filteredResults = context.Properties.Where(x =>
                (filter.City != "" ? x.City == filter.City : true) &&
                (filter.Baths != 0 ? x.NumberOfBaths == filter.Baths : true) &&
                (filter.Beds != 0 ? x.NumberOfBeds == filter.Beds : true) &&
                (filter.SqftMin != 0 ? x.SquareFeet >= filter.SqftMin : true) &&
                (filter.SqftMax != 0 ? x.SquareFeet <= filter.SqftMax : true) &&
                (filter.PriceMin != 0 ? x.Price >= filter.PriceMin : true) &&
                (filter.PriceMax != 0 ? x.Price <= filter.PriceMax : true)).ToList();



                return View(filteredResults);
            }
        }

        public ActionResult PropertyDetails(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.Identity.GetUserId();
                    var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();

                    var hasFavorite = user.Properties.Where(x => x.Id == id).FirstOrDefault();
                    if (hasFavorite != null)
                    {
                        ViewBag.Favorite = true;
                    }
                    else
                    {
                        ViewBag.Favorite = false;
                    }
                }

                var property = context.Properties.Where(x => x.Id == id).FirstOrDefault();

                return View(property);
            }
        }

        public ActionResult RemoveFavorite(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.Identity.GetUserId();
                    var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();

                    var favorite = user.Properties.Where(x => x.Id == id).FirstOrDefault();
                    user.Properties.Remove(favorite);
                    context.SaveChanges();
                }

            }
            return RedirectToAction("Favorites");

        }

        //Featured Properties for the partial in Home/Index
        public ActionResult FeaturedProperties()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var featured = context.Properties.Where(x => x.IsFeatured == true).ToList();
                if (featured != null)
                {
                    return View(featured);
                }
            }
            return View();
        }

        public ActionResult AddToFavorites(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var user = context.Users.Single(x => x.Id == userId);
                var newProperty = context.Properties.Where(x => x.Id == id).FirstOrDefault();
                user.Properties.Add(newProperty);
                context.SaveChanges();
                return RedirectToAction("Favorites");
            }
        }

        [Authorize]
        public ActionResult Favorites()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var userId = User.Identity.GetUserId();
                    var user = context.Users.Single(x => x.Id == userId);
                    return View(user.Properties.ToList());
                }
            }
            return View();
        }

    }
}