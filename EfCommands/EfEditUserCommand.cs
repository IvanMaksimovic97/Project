using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EfCommands
{
    public class EfEditUserCommand : EfBaseCommand, IEditUserCommand
    {
        public EfEditUserCommand(Context context) : base(context)
        {
        }

        public void Execute(EditUserDTO request)
        {
            if (Validate(request))
            {
                var user = context.Users.Find(request.UserId);

                if(user.FirstName != null)
                {
                    user.FirstName = request.FirstName;
                }

                if (user.LastName != null)
                {
                    user.LastName = request.LastName;
                }

                if (user.Password != null)
                {
                    user.Password = CreateSha256Hash(request.Password);
                }

                if (user.Role != null)
                {
                    user.Role = request.Role;
                }

                user.ModifiedAt = DateTime.Now;

                context.SaveChanges();
            }
        }

        public bool Validate(EditUserDTO dto)
        {
            if (!context.Users.Any(m => m.Id == dto.UserId))
                throw new EntityNotFoundException("Korisnik nije pronadjen");

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
