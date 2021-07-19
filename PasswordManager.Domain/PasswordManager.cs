using System;

namespace PasswordManager.Domain
{
    internal static class PasswordManager
    {
        public static bool ValidatePassword(string password)
        {
            var validLength = false;
            var capitalCharacter = false;
            var tinyCharacter = false;
            var specialCharacter = false;
            var repeatedCharacter = false;

            if (password.Length >= 15)
                validLength = true;

            char previousCharacter = '\u0000';
            foreach (var character in password)
            {
                if (character == previousCharacter)
                    repeatedCharacter = true;

                if (char.IsUpper(character))
                    capitalCharacter = true;
                else if (char.IsLower(character))
                    tinyCharacter = true;
                else if
                    (character == '@' || character == '#' || character == '_' || character == '-' || character == '!')
                    specialCharacter = true;
                previousCharacter = character;
            }

            return validLength && capitalCharacter && tinyCharacter && specialCharacter && !repeatedCharacter;
        }

        public static string GeneratePassword()
        {
            var password = "";
            var random = new Random();
            var previousCharacter = '\u0000';
            for (int i = 0; i < random.Next(15, 25) - 2; i++)
            {
                char character;
                if (i == 0)
                {
                    password += GetSetupCharacteres(random.Next(1, 4));
                    character = char.Parse(password.Substring(2, 1));
                }
                else
                {
                    do
                    {
                        var group = random.Next(1, 5);
                        if (group == 1)
                            character = char.Parse(GetCharacterFromGroupOne());
                        else if (group == 2)
                            character = char.Parse(GetCharacterFromGroupTwo());
                        else if (group == 3)
                            character = char.Parse(GetCharacterFromGroupThree());
                        else
                            character = char.Parse(GetCharacterFromGroupFour());
                    } while (character == previousCharacter);
                    password += character;
                }
                previousCharacter = character;
            }

            return password;
        }

        private static string GetSetupCharacteres(int group)
        {
            if (group == 1)
                return string.Concat(
                    GetCharacterFromGroupThree() + GetCharacterFromGroupTwo() + GetCharacterFromGroupOne());
            if (group == 2)
                return string.Concat(
                    GetCharacterFromGroupOne() + GetCharacterFromGroupThree() + GetCharacterFromGroupTwo());
            return string.Concat(
                GetCharacterFromGroupOne() + GetCharacterFromGroupTwo() + GetCharacterFromGroupThree());
        }

        private static string GetCharacterFromGroupOne() =>
            "abcdefghijklmnopqrstuvwxyz".Substring(new Random().Next(0, 25), 1);

        private static string GetCharacterFromGroupTwo() =>
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(new Random().Next(0, 25), 1);

        private static string GetCharacterFromGroupThree() =>
            "@#_-!".Substring(new Random().Next(0, 4), 1);

        private static string GetCharacterFromGroupFour() =>
            "0123456789".Substring(new Random().Next(0, 9), 1);
    }
}