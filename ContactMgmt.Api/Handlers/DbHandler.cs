using System.Collections.Generic;
using System.Linq;
using AutoMapper.Internal;
using ContactMgmt.Api.Models;
using ContactMgmt.DbManager;
using TagValue = ContactMgmt.DbManager.TagValue;

namespace ContactMgmt.Api.Handlers
{
    public class DbHandler : IDbHandler
    {
        private CMSEntities dbEntities;

        public DbHandler()
        {
            dbEntities = new CMSEntities();
        }

        public IQueryable<Contact> GetBasicContactInformation(string searchString)
        {
            return dbEntities.Contacts.Where(x =>
                                        x.FirstName.StartsWith(searchString) ||
                                        x.LastName.StartsWith(searchString) ||
                                        x.PrimaryContact.StartsWith(searchString)
                )
                .Take(20);
        }

        public IQueryable<Contact> FirstNameStartsWith(string searchString)
        {
            return dbEntities.Contacts.Where(x =>
                x.FirstName.StartsWith(searchString));
        }

        public void Save(FullContactInformation contactInformation)
        {
            var tags = new List<TagValue>();
            contactInformation.TagValues.Each(x => tags.Add(new TagValue() { TagType_Id = x.TagTypeId, Value = x.Value, Contact_Id = contactInformation.ContactId }));
            if (contactInformation.ContactId == -1)
            {
                var contact = new Contact()
                {
                    Email = contactInformation.Email,
                    FirstName = contactInformation.FirstName,
                    LastName = contactInformation.LastName,
                    PrimaryContact = contactInformation.PrimaryContact
                };

                contact.TagValues = tags;
                dbEntities.Contacts.Add(contact);
            }
            else
            {
                var dbContact = dbEntities.Contacts.First(x => x.Contacts_Id == contactInformation.ContactId);
                dbContact.FirstName = contactInformation.FirstName;
                dbContact.LastName = contactInformation.LastName;
                dbContact.PrimaryContact = contactInformation.PrimaryContact;
                dbContact.Email = contactInformation.Email;

                foreach (var tag in contactInformation.TagValues)
                {
                    if (dbContact.TagValues.All(x => x.TagType_Id != tag.TagTypeId))
                        dbContact.TagValues.Add(new TagValue() { TagType_Id = tag.TagTypeId, Value = tag.Value, Contact_Id = contactInformation.ContactId });
                    else
                    {
                        var contact = dbContact.TagValues
                            .First(x => x.TagType_Id == tag.TagTypeId);
                        contact.Value = tag.Value;
                    }   
                }
            }
            dbEntities.SaveChanges();
        }

        public void DeleteContact(long id)
        {
            var contact = dbEntities.Contacts.First(x => x.Contacts_Id == id);
            dbEntities.Contacts.Remove(contact);
            dbEntities.SaveChanges();
        }

        public IQueryable<Contact> GetFullContactById(long id)
        {
            return dbEntities.Contacts.Where(x => x.Contacts_Id == id);
        }

        public IQueryable<TagType> GetTagTypes()
        {
            return dbEntities.TagTypes;
        }
    }
}