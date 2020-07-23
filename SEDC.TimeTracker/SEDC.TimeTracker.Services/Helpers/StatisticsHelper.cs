using SEDC.TimeTracker.Domain.Entities;
using SEDC.TimeTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.TimeTracker.Services.Helpers
{
    public static class StatisticsHelper
    {
        public static ReadingType FavoriteReadingType(User user)
        {
            int bellesLettres = 0;
            int fiction = 0;
            int professionalLiterature = 0;
            ReadingType favorite;
            for (int i = 0; i < user.ReadingSessions.Count; i++)
            {
                if (user.ReadingSessions[i].Type == ReadingType.BellesLettres)
                {
                    bellesLettres++;
                }
                else if (user.ReadingSessions[i].Type == ReadingType.Fiction)
                {
                    fiction++;
                }
                else if (user.ReadingSessions[i].Type == ReadingType.ProfessionalLiterature)
                {
                    professionalLiterature++;
                }
            }


            favorite = ReadingType.BellesLettres;
            if (fiction > bellesLettres)
            {
                favorite = ReadingType.Fiction;
            }
            if (professionalLiterature > bellesLettres && professionalLiterature > fiction)
            {
                favorite = ReadingType.ProfessionalLiterature;
            }

            return favorite;
        }

        public static ExercisingType FavoriteExercisingType(User user)
        {
            int general = 0;
            int running = 0;
            int sport = 0;
            ExercisingType favorite;

            for (int i = 0; i < user.ExercisingSessions.Count; i++)
            {
                if (user.ExercisingSessions[i].Type == ExercisingType.General)
                {
                    general++;
                }
                else if (user.ExercisingSessions[i].Type == ExercisingType.Running)
                {
                    running++;
                }
                else if (user.ExercisingSessions[i].Type == ExercisingType.Sport)
                {
                    sport++;
                }
            }
            

            favorite = ExercisingType.General;
            if (running > general)
            {
                favorite = ExercisingType.Running;
            }
            if (sport > general && sport > running)
            {
                favorite = ExercisingType.Sport;
            }

            return favorite;
        }

        public static List<string> AllHobbiesNames(User user)
        {
            List<string> namesOfHobbies = new List<string>();
            var allHobbies =  user.AllHobbbies.Select(x => x.Name).ToList();
            namesOfHobbies.Add(allHobbies[0]);
            bool exists = false;
            foreach (var name in allHobbies)
            {
                foreach (var added in namesOfHobbies)
                {
                    if (name == added)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    namesOfHobbies.Add(name);
                }
                
            }
            return namesOfHobbies;
            
        }

        public static int TotalTime<T>(List<T> items) where T : Activities
        {
            var totalTime = 0;
            foreach (var item in items)
            {
                totalTime += item.SessionTime;
            }
            return totalTime;
        }

    }
}
