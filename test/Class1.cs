using MYP_MassageSalon.DAL;
using MYP_MassageSalon.DAL.Dtos;
using System;
using System.IO;
namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppointmentDTO dto = new AppointmentDTO()
            {
                ClientId = 8

            };

            AppointmentnRepository appointRepository = new AppointmentnRepository();

            appointRepository.AddAppointment(dto);

        }

    }
}


