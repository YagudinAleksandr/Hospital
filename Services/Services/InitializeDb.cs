using DataContext.Context;
using DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    /// <summary>
    /// Первичная инициализация базы данных
    /// </summary>
    public class InitializeDb
    {
        private readonly DataDB db;
        public InitializeDb(DataDB db)
        {
            this.db = db;
        }

        /// <summary>
        /// Метод запуска инициализаций
        /// </summary>
        public void Initialize()
        {
            db.Database.Migrate();

            this.InitializeOffices();
            this.InitializeSectors();
            this.InitializeSpecializations();
            this.InitializationDoctors();
            this.InitializationPatients();
        }


        /// <summary>
        /// Инициализация кабинетов
        /// </summary>
        private void InitializeOffices()
        {
            if (!db.Offices.Any())
            {
                List<Office> offices = new List<Office>
                {
                    new Office() { Name = "1" },
                    new Office() { Name = "2" },
                    new Office() { Name = "3" },
                    new Office() { Name = "4" },
                    new Office() { Name = "5" },
                    new Office() { Name = "6" }
                };

                db.AddRange(offices);
                db.SaveChanges();
            }
        }

       /// <summary>
       /// Инициализация участков
       /// </summary>
        private void InitializeSectors()
        {
            if (!db.Sectors.Any())
            {
                List<Sector> sectors = new List<Sector>
                {
                    new Sector() { Name = "1"},
                    new Sector() { Name = "2"},
                    new Sector() { Name = "3" },
                    new Sector() { Name = "4" }
                };

                db.AddRange(sectors);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Инициализация специализаций
        /// </summary>
        private void InitializeSpecializations()
        {
            if (!db.Specializations.Any())
            {
                List<Specialization> specializations = new List<Specialization>
                {
                    new Specialization() { Name = "Терапевт"},
                    new Specialization() { Name = "Хирург" },
                    new Specialization() { Name = "Оторинолоринголо" },
                    new Specialization() { Name = "Кардиолог" },
                    new Specialization() { Name ="Гинеколог" },
                    new Specialization() { Name = "Уролог" },
                    new Specialization() { Name = "Психиатор" },
                    new Specialization() { Name = "Окулист" },
                    new Specialization() { Name = "Ортопед" }
                };

                db.AddRange(specializations);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Инициализация врачей
        /// </summary>
        private void InitializationDoctors()
        {
            if (!db.Doctors.Any())
            {
                List<Doctor> doctors = new List<Doctor>
                {
                    new Doctor(){
                        Fullname="Иванов Сергей Петрович",
                        Office = db.Offices.FirstOrDefault(o => o.Id == 1),
                        Specialization = db.Specializations.FirstOrDefault(s => s.Id == 2),
                        Sector = db.Sectors.FirstOrDefault(s => s.Id == 3),
                    },
                    new Doctor(){
                        Fullname="Иванов Василий Степанович",
                        Office = db.Offices.FirstOrDefault(o => o.Id == 2),
                        Specialization = db.Specializations.FirstOrDefault(s => s.Id == 2),
                        Sector = db.Sectors.FirstOrDefault(s => s.Id == 1),
                    },
                    new Doctor(){
                        Fullname="Панкова Мария Геннадьевна",
                        Office = db.Offices.FirstOrDefault(o => o.Id == 4),
                        Specialization = db.Specializations.FirstOrDefault(s => s.Id == 3),
                    },
                    new Doctor(){
                        Fullname="Панкова Елена Геннадьевна",
                        Office = db.Offices.FirstOrDefault(o => o.Id == 4),
                        Specialization = db.Specializations.FirstOrDefault(s => s.Id == 6),
                    },
                };

                db.AddRange(doctors);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Инициализация пациентов
        /// </summary>
        private void InitializationPatients()
        {
            if (!db.Doctors.Any())
            {
                List<Patient> patients = new List<Patient>
                {
                    new Patient()
                    {
                        Surename = "Пак",
                        Name = "Василий",
                        Patronymic = "Андреевич",
                        Address = "Улица Сведлва, 17",
                        Sex = "MALE",
                        Birthday = System.DateTime.Now,
                        Sector = db.Sectors.FirstOrDefault(s => s.Id == 3)
                    }
                };

                db.AddRange(patients);
                db.SaveChanges();
            }
        }
    }
}
