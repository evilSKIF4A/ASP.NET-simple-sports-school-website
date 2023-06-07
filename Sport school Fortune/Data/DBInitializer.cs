using Sport_school_Fortune.Models;
using System.Linq;
using System;

namespace Sport_school_Fortune.Data
{
    public class DBInitializer
    {
        public static void Initial(SchoolContext context)
        {
            if (!context.Sportsmans.Any())
            {
                context.Sportsmans.AddRange(
                    new Sportsman
                    {
                        f_name = "Силкин", s_name = "Дмитрий", m_name = "Дмитриевич",
                        gender = "Мужской", birthday = new DateTime(2000,11,11).ToShortDateString(), phone = 946834,
                        weight = 70, height = 185
                    },
                    new Sportsman
                    {
                        f_name = "Щупляков",
                        s_name = "Александр",
                        m_name = "Александрович",
                        gender = "Мужской",
                        birthday = new DateTime(2000, 01, 21).ToShortDateString(),
                        phone = 975345,
                        weight = 50,
                        height = 172
                    }
                );
            }
            context.SaveChanges();

            if (!context.Sports.Any())
            {
                context.Sports.AddRange(
                    new Sport
                    {
                        sport_name = "Шахматы"
                    },
                    new Sport
                    {
                        sport_name = "Танцы"
                    }
                );
            }
            context.SaveChanges();

            if (!context.Trainers.Any())
            {
                context.Trainers.AddRange(
                    new Trainer
                    {
                        f_name = "Иванов",
                        s_name = "Артем",
                        m_name = "Иванович",
                        gender = "Мужской",
                        birthday = new DateTime(1968, 06, 12).ToShortDateString(),
                        phone = 974352,
                        sportId = 1
                    },
                    new Trainer
                    {
                        f_name = "Дарк",
                        s_name = "Жанна",
                        m_name = "Ивановна",
                        gender = "Женский",
                        birthday = new DateTime(1988, 04, 22).ToShortDateString(),
                        phone = 985735,
                        sportId = 2
                    }
                    );
            }
            context.SaveChanges();

            if (!context.Journals.Any())
            {
                context.Journals.AddRange(
                    new Journal
                    {
                        sportsmanId = 1,
                        sportId = 1,
                        trainerId = 1
                    },
                    new Journal
                    {
                        sportsmanId = 2,
                        sportId = 2,
                        trainerId = 2
                    }
                    );
            }
            context.SaveChanges();

            if (!context.Activitys.Any())
            {
                context.Activitys.AddRange(
                    new Activity
                    {
                        sportId = 1,
                        date = new DateTime(2021, 04, 05).ToShortDateString(),
                        name = "Школьный этап по шахматам"
                    },
                    new Activity
                    {
                        sportId = 2,
                        date = new DateTime(2022, 05, 15).ToShortDateString(),
                        name = "Школьный этап по танцам"
                    }
                    );
            }
            context.SaveChanges();

            if (!context.Members.Any())
            {
                context.Members.AddRange(
                    new Member
                    {
                        sportsmanId = 1,
                        activityId = 1,
                        place = 1
                    },
                    new Member
                    {
                        sportsmanId = 2,
                        activityId = 2,
                        place = 1
                    }
                    );
            }
            context.SaveChanges();
        }

    }
}
