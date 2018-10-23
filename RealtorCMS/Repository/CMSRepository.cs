using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealtorCMS.Models;
using System.IO;
using RealtorCMS.Repository;
using Microsoft.AspNet.Identity;

namespace RealtorCMS.Repository
{
    public class CMSRepository
    {
        public IEnumerable<Property> GetAllProperties()
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Properties.ToList();
            }
        }
        public Property FindPropertyById(int? id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Properties.Find(id);
            }
        }
        public void CreateProperty(PropertyViewModel property)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {

            var fileName = Path.GetFileName(property.File.FileName);
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images"), fileName);
            property.File.SaveAs(path);

            var temp = new Property
            {
                Address = property.Address,
                City = property.City,
                CreateDate = DateTime.Now,
                Description = property.Description,
                IsFeatured = property.IsFeatured,
                SquareFeet = property.SquareFeet,
                MapLink = property.MapLink,
                NumberOfBaths = property.NumberOfBaths,
                NumberOfBeds = property.NumberOfBeds,
                PropertyType = property.PropertyType,
                Price = property.Price,
                YouTubeLink = property.YouTubeLink,
                ImagePath = fileName
            };

            db.Properties.Add(temp);
            db.SaveChanges();
            }
        }
        public void EditProperty(Property property)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void RemoveProperty(int id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                Property property = db.Properties.Find(id);
                db.Properties.Remove(property);
                db.SaveChanges();
            }
        }
        public IEnumerable<Blog> GetAllBlogs()
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Blogs.ToList();
            }
        }
        public Blog FindBlogById(int? id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Blogs.Find(id);
            }
        }
        public void CreateBlog(BlogViewModel blog)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var fileName = Path.GetFileName(blog.File.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images"), fileName);
                blog.File.SaveAs(path);

                Blog temp = new Blog()
                {
                    Title = blog.Title,
                    Content = blog.Content,
                    CreationDate = DateTime.Now,
                    PicturePath = fileName
                };
                db.Blogs.Add(temp);
                db.SaveChanges();
            }
        }
        public void EditBlog(Blog blog)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteBlog(int id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                Blog blog = db.Blogs.Find(id);
                db.Blogs.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}