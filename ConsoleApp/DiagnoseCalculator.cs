using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DiagnoseCalculator
    {
        public static void Calculate(User user, int questionsAmount)
        {
            var percentForDiagnoses = user.CalculatedAnswers * 100 / questionsAmount;
            var diagnoses = GetDiagnoses();

            if (0 <= percentForDiagnoses && percentForDiagnoses < 16)
            {
                user.Diagnose = diagnoses[0];
                return;
            }
            if (16 <= percentForDiagnoses && percentForDiagnoses < 33)
            {
                user.Diagnose = diagnoses[1];
                return;
            }
            if (33 <= percentForDiagnoses && percentForDiagnoses < 50)
            {
                user.Diagnose = diagnoses[2];
                return;
            }
            if (50 <= percentForDiagnoses && percentForDiagnoses < 66)
            {
                user.Diagnose = diagnoses[3];
                return;
            }
            if (66 <= percentForDiagnoses && percentForDiagnoses < 83)
            {
                user.Diagnose = diagnoses[4];
                return;
            }

            user.Diagnose = diagnoses[5];
        }
        static string[] GetDiagnoses()
        {
            string[] diagnoses = new string[6];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";
            return diagnoses;
        }
    }
}
