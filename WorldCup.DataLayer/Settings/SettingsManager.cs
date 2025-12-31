using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WorldCup.DataLayer.Exceptions;
using WorldCup.DataLayer.Models;

namespace WorldCup.DataLayer
{
    public static class SettingsManager
    {
        private static readonly string basePath =
            Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    @"..\..\..\WorldCup.DataLayer\Resources\Settings"
                )
            );
        
        internal static readonly List<string>
            ValidLanguages = ["en", "hr"];

        internal static readonly List<string>
            ValidCategory = ["F", "M"];

        internal static readonly List<string> 
            ValidMethods = ["JSON", "API"];

        internal static readonly List<string>
            ValidSizes = ["Small", "Medium", "Full"];
        
        public static bool WPF {  get; set; }
        public static bool CategoryIsChanged { get; set; }

        private static string language;
        public static string Language 
        {
            get => language;
            set => language = value;
        }
        
        private static string category;
        public static string Category 
        { 
            get => category;
            set => category = value;            
        }
        
        private static string loadMethod;
        public static string LoadMethod 
        {
            get => loadMethod;
            set => loadMethod = value;
        }

        private static string screen;
        public static string Screen
        {
            get => screen;
            set => screen = value;
        }

        private static List<Player> playersFavorite;
        public static List<Player> PlayersFavorite
        {
            get => playersFavorite ?? new List<Player>();
            set
            {
                playersFavorite = value;
                SaveFavorites<List<Player>>(playersFavorite, "\\Favorite_players.txt");
            }
        }

        private static Team teamFavorite = new();      
        public static int TeamFavoriteId
        {
            get => teamFavorite?.Id ?? 0;
            set => teamFavorite?.Id = value;
        }
        public static string TeamFavoriteName
        {
            get => teamFavorite?.Country;
        }
        public static Object TeamFavorite
        {
            get => teamFavorite;
            set
            {
                if (value != null)
                {
                    if (!string.IsNullOrEmpty(teamFavorite?.Country) 
                    && (value as Team).Country != teamFavorite?.Country)
                    {
                        RemoveFavorites();        
                    }

                    teamFavorite = (Team)value;
                    SaveFavorites<Team>(teamFavorite, "\\Favorite_team.txt");
                }

                else 
                    teamFavorite = null;

            }
        }

        private static Match matchFavorite = new();
        public static Match MatchFavorite
        {
            get => matchFavorite;
            set
            {
                if(value != null)
                {
                    if (value.ToString() != matchFavorite?.ToString())
                    {
                        File.Delete(basePath + "\\Favorite_match.txt");
                    }

                    matchFavorite = value;
                    SaveFavorites<Match>(matchFavorite, "\\Favorite_match.txt");
                }

                else
                    matchFavorite = null;
            }
        }
        public static void RemoveFavorites()
        {
            File.Delete(basePath + "\\Favorite_team.txt");
            File.Delete(basePath + "\\Favorite_match.txt");
            File.Delete(basePath + "\\Favorite_players.txt");

            teamFavorite = null;
            matchFavorite = null;
            playersFavorite?.Clear();
        }
        private static void SaveFavorites<T>(T favorite, string extension)
        {
            string path = string.Concat(basePath, extension);            

            try
            {
                File.WriteAllText(path, $"{FavoritesForFile(favorite)}");

            }
            catch (Exception error)
            {
                string AdditionalInfo = ExceptionProcessor.ProcessException(error).ToString();

                MessageBox.Show(
                    $"Error while saveing inforamtion!\n" +
                    $"Error description: {error.Message}\n" +
                    $"Consequences: Choosen option can't be saved.\n" +
                    AdditionalInfo,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private static object FavoritesForFile<T>(T favorite)
        {
            string textForFile = string.Empty;

            switch (favorite)
            {
                case Team:
                    Team team = favorite as Team;

                    textForFile = $"team={team.Id}";
                break;                

                case List<Player>:
                    List<Player> players = favorite as List<Player>;                    

                    foreach (Player player in players)                    
                        textForFile += player;
                    
                break;

                case Match: 
                    Match match = favorite as Match;

                    textForFile = 
                        $"homeTeam={match.Home_team_country}\n" +
                        $"awayTeam={match.Away_team_country}\n";
                break;

                default: throw new Exception(
                    "Unkonw type of option occured while parsing for file"
                );

            }

            return textForFile;
        }

        public static void SaveSettings()
        {
            string path = string.Concat(basePath, "\\Settings_file.txt");

            try
            {
                File.WriteAllText(path, InitializationForFile());
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"Error occured while trying to save data!\n" +
                    $"Error description: {error.Message}\n",
                    $"Consenquences: Saveing settings might not work.\n" +
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public static bool StartUpIsNessecary = false;
        public static bool CheckForSettings(bool loadSettings = true)
        {
            if(loadSettings)
                LoadSettings();

            bool exists = true;

            if (string.IsNullOrEmpty(language))
                exists = false;

            else if (string.IsNullOrEmpty(category))
                exists = false;

            else if(string.IsNullOrEmpty(loadMethod))
                exists = false;

            else if(WPF)
                exists = !string.IsNullOrEmpty(screen);

            return exists;
        }
        public static void InitializeSettings()
        {
            LanguageManager.InitializeLanguageKeys();
            CategoryManager.InitializeCategory();
        }
        private static string InitializationForFile()
        {
            return $"language={language}\n" +
                   $"gender={category}\n" +
                   $"load={loadMethod}\n" +
                   $"size={screen}\n";
        }

        public static void LoadSettings()
        {
            string path = string.Concat(basePath, "\\Settings_file.txt");

            if (!File.Exists(path))
                return;
            
            try
            {
                string[] data = ReadFromFile(path);
 
                if (data != null
                && ValidLanguages.Contains(data[0])
                && ValidCategory.Contains(data[1])
                && ValidMethods.Contains(data[2]))
                {
                    language = data[0];
                    category = data[1];
                    loadMethod = data[2];

                    if (WPF && ValidSizes.Contains(data[3]))
                        screen = data[3];
                }

                else
                {
                    throw new Exception(
                        $"Data is in an unsupported format!\n" +
                        $"Solution: Forwarding the request to the settings form."
                    );
                }                            
            }

            catch (Exception error)
            {
                DisplayErrorInformation(error);
            }
        }
        public static void LoadFavoritePlayers()
        {
            string path = string.Concat(basePath, "\\Favorite_players.txt");

            if (!File.Exists(path))
                return;

            try
            {
                string[] data = ReadFromFile(path);

                playersFavorite = [];
                for (int i = 0; i < data.Length - 1; i += 5)
                {
                    try
                    {
                        playersFavorite.Add(
                            new Player
                            {
                                Name = data[i],
                                Captain = bool.Parse(data[i + 1]),
                                Shirt_Number = int.Parse(data[i + 2]),
                                Position = data[i + 3],
                                Country = data[i + 4],
                            }
                        );
                    }
                    catch (Exception error)
                    {
                        throw new Exception(
                            $"Pata is in an unsupported format!\n" +
                            $"Consequences: Unable to display saved favorited players.", error
                        );
                    }
                }
            }
            catch (Exception error)
            {
                DisplayErrorInformation(error);
            }
        }
        public static void LoadFavoriteTeam()
        {
            string path = string.Concat(basePath, "\\Favorite_team.txt");

            if (!File.Exists(path))
                return;

            try
            {
                string[] data = ReadFromFile(path);

                if (int.TryParse(data[0], out int id))
                    TeamFavoriteId = id;

                else
                    throw new Exception(
                        $"Data is in an unsupported format!\n" +
                        $"Consequences: Unable to display saved favorite team."
                    );
            }
            catch (Exception error)
            {
                DisplayErrorInformation(error);
            }
        }
        public static void LoadFavoriteMatch()
        {
            string path = string.Concat(basePath, "\\Favorite_match.txt");

            if (!File.Exists(path))
                return;

            try
            {
                string[] data = ReadFromFile(path);

                string home = data[0];
                string away = data[1];

                if (home == TeamFavoriteName || away == TeamFavoriteName)
                {
                    matchFavorite.Home_team_country = home;
                    matchFavorite.Away_team_country = away;
                }

                else
                {
                    matchFavorite = null;

                    throw new Exception(
                        $"Data is in an unsupported format!\n" +
                        $"Consequences: Unable to display saved favorite match."
                    );
                }
            }
            catch (Exception error)
            {
                DisplayErrorInformation(error);
            }
        }
        private static string[] ReadFromFile(string path)
        {
            string text = File.ReadAllText(path);

            string[] result = text.Split('\n');

            for (int i = 0; i < result.Length; i++)
            {
                int index = result[i].IndexOf('=') + 1;

                result[i] = result[i].Substring(index);
            }

            return result;
        }

        private static void DisplayErrorInformation(Exception error)
        {
            string AdditionalInfo =
                ExceptionProcessor.ProcessException(error)?.ToString();

            MessageBox.Show(
                $"Error while loading data!\n" +
                $"Error description: " + error.Message + "\n" +
                AdditionalInfo ?? string.Empty,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }     
}
