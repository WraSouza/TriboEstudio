using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriboEstudio.Model;

namespace TriboEstudio.FirebaseServices
{
    internal class ProfessorServices
    {
        FirebaseClient firebase;

        public ProfessorServices()
        {
            firebase = new FirebaseClient("https://triboestudio-d0828-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> LoginUser(string name, string passwd)
        {
            bool result = false;
            try
            {
                var user = (await firebase.Child("Professor")
                .OnceAsync<Professor>())
                .Where(u => u.Object.UserName == name)
                .Where(u => u.Object.Password == passwd)
                .FirstOrDefault();

                result = true;

                return (user != null);
            }catch(Exception ex)
            {
               await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }

            return result;
            
        }

        public async Task<bool> AdicionarProfessor(Professor professor)
        {
            bool resultado = true;
            await firebase.Child("Professor")
                .PostAsync(new Professor
                {
                    Name = professor.Name,
                    Password = professor.Password,
                    IsActive= professor.IsActive,
                    Id = professor.Id,
                    UserName = professor.UserName,
                    Salario= professor.Salario,
                    CurrentMonth= professor.CurrentMonth,
                    IsSalaryPaid = professor.IsSalaryPaid

                });

            return resultado;
        }
    }
}
