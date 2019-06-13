using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EfCommands
{
    public class EfCreateUserCommand : EfBaseCommand, ICreateUserCommand
    {
        public EfCreateUserCommand(Context context) : base(context)
        {
        }

        public void Execute(CreateUserDTO request)
        {
            if (Validate(request))
            {
                var user = new User
                {
                    CreatedAt = DateTime.Now,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = CreateSha256Hash(request.Password),
                    Role = request.Role
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool Validate(CreateUserDTO request)
        {
            if (context.Users.Any(x => x.Email == request.Email))
                throw new EntityAlreadyExist("Email: " + request.Email);

            return true;
        }

        public static string CreateSha256Hash(string input)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
