using UnityEngine;
using System.Collections;

public class PrefsManager : MonoBehaviour
{
    public static string TotalCoins = "TotalCoins";
    public static string CurrentGamePlayCoins = "CurrentGamePlayCoins";
    public static string TotelFires = "TotelFires";
    public static string CurrentGamePlayFires = "CurrentGamePlayFires";
    public static string BottleFlipGamesCount = "BottleFlipGamesCount";
    public static string DumpBottleGamesCount = "DumpBottleGamesCount";
    public static string TotalSuccessFullFlips = "TotalSuccessFullFlips";
    public static string TotalSuccessFullDumps = "TotalSuccessFullDumps";


    public static string BestBottleFlipsCount = "BestBottleFlipsCount";
    public static string CurrentBottleFlipsCount = "CurrentBottleFlipsCount";
    public static string BestBottleDumpsCount = "BestBottleDumpsCount";
    public static string CurrentBottleDumpsCount = "CurrentBottleDumpsCount";

    public static string BestCoins = "BestCoins";


    public static void setFirstTimePLay()
    {
        PlayerPrefs.SetInt("isFirstTimePlay", 1);
        PlayerPrefs.Save();
    }

    public static void ResetCurrentStats()
    {
        PlayerPrefs.DeleteKey(CurrentBottleFlipsCount);
        PlayerPrefs.DeleteKey(CurrentBottleDumpsCount);
        ResetGameplayCoins();
    }

    public static int GetBestBottleFlipCount()
    {
        return PlayerPrefs.GetInt(BestBottleFlipsCount);
    }

    public static void SetBestBottleFlipCount(int Score)
    {
        PlayerPrefs.SetInt(BestBottleFlipsCount, Score);
    }

    public static int GetBestBottleDumpCount()
    {
        return PlayerPrefs.GetInt(BestBottleDumpsCount);
    }

    public static void SetBestBottleDumpCount(int score)
    {
        PlayerPrefs.SetInt(BestBottleDumpsCount, score);
    }

    public static int GetCurrentBottleFlipsCount()
    {
        return PlayerPrefs.GetInt(CurrentBottleFlipsCount);
    }

    public static void AddToCurrentBottleFlipCount()
    {
        PlayerPrefs.SetInt(CurrentBottleFlipsCount, GetCurrentBottleFlipsCount() + 1);
    }

    public static void AddToBottleFlipGameCount()
    {
        PlayerPrefs.SetInt(BottleFlipGamesCount, GetBottleFlipGameCount() + 1);
    }

    public static int GetBottleFlipGameCount()
    {
        return PlayerPrefs.GetInt(BottleFlipGamesCount);
    }

    public static int GetCurrentBottleDumps()
    {
        return PlayerPrefs.GetInt(CurrentBottleDumpsCount);
    }

    public static void AddToCurrentBottleDumps()
    {
        PlayerPrefs.SetInt(CurrentBottleDumpsCount, GetCurrentBottleDumps());
    }

    public static void AddToDumpBottleGameCount()
    {
        PlayerPrefs.SetInt(DumpBottleGamesCount, GetDumpBottleGameCount() + 1);
    }

    public static int GetDumpBottleGameCount()
    {
        return PlayerPrefs.GetInt(DumpBottleGamesCount);
    }

    public static int GetTotalSuccessFullFlips()
    {
        return PlayerPrefs.GetInt(TotalSuccessFullFlips);
    }

    public static void AddToTotalSuccessFullFlips()
    {
        PlayerPrefs.SetInt(TotalSuccessFullFlips, GetTotalSuccessFullFlips() + 1);
    }

    public static int GetTotalSuccessFullDumps()
    {
        return PlayerPrefs.GetInt(TotalSuccessFullDumps);
    }

    public static void AddToTotalSuccessFullDumps()
    {
        PlayerPrefs.SetInt(TotalSuccessFullDumps, GetTotalSuccessFullDumps() + 1);
    }

    public static int getFirstTimePlayStatus()
    {
        return PlayerPrefs.GetInt("isFirstTimePlay");
    }

    public static int TimesPlayed()
    {
        return PlayerPrefs.GetInt("TimesPlayed");
    }

    public static void ResetTimesPlayed()
    {
        PlayerPrefs.SetInt("TimesPlayed", 0);
        PlayerPrefs.Save();
    }

    public static void IncreaseTimesPlayed()
    {
        PlayerPrefs.SetInt("TimesPlayed", (TimesPlayed()) + 1);
        PlayerPrefs.Save();
    }

    public static int GetBestCoins()
    {
        return PlayerPrefs.GetInt(BestCoins);
    }

    public static void SetBestCoins(int coins)
    {
        PlayerPrefs.SetInt(BestCoins, coins);
    }

    public static int GetCurrentGamePlayCoins()
    {
        return PlayerPrefs.GetInt(CurrentGamePlayCoins);
    }

    public static int GetTotalCoins()
    {
        return PlayerPrefs.GetInt(TotalCoins);
    }


    public static int GetCurrentGamePlayFires()
    {
        return PlayerPrefs.GetInt(CurrentGamePlayFires);
    }

    public static int GetTotalFires()
    {
        return PlayerPrefs.GetInt(TotelFires);
    }


    public static void MuteAudio()
    {
        PlayerPrefs.SetString("Audio", "Mute");
    }

    public static void UnMuteAudio()
    {
        PlayerPrefs.SetString("Audio", "UnMute");
    }

    public static bool IsMuteAudio()
    {
        return PlayerPrefs.GetString("Audio") == "Mute";
    }

    public static bool IsUnMuteAudio()
    {
        return PlayerPrefs.GetString("Audio") == "UnMute";
    }


    public static void SetHighestDistance(int Distance)
    {
        PlayerPrefs.SetInt("HighestDistance", Distance);
    }

    public static int GetHighestDistance()
    {
        return PlayerPrefs.GetInt("HighestDistance");
    }


    public static void AddToCurrentCoins(int x)
    {
        PlayerPrefs.SetInt(CurrentGamePlayCoins, GetCurrentGamePlayCoins() + x);
    }

    public static void ResetGameplayCoins()
    {
        PlayerPrefs.DeleteKey(CurrentGamePlayCoins);
    }

    public static void SubtractFromTotalCoins(int coins)
    {
        PlayerPrefs.SetInt(TotalCoins, GetTotalCoins() - coins);
    }

    public static void AddToTotalCoins(int x)
    {
        PlayerPrefs.SetInt(TotalCoins, GetTotalCoins() + x);
    }

    public static void ResetCurrentGamePlayCoins()
    {
        PlayerPrefs.SetInt(CurrentGamePlayCoins, 0);
    }

    public static void setFireDealIndex(int dealNo)
    {
        PlayerPrefs.SetInt("FireDeal", dealNo);
        PlayerPrefs.Save();
    }

    public static int getfireDeal()
    {
        return PlayerPrefs.GetInt("FireDeal");
    }

    public static void AddToCurrentFires()
    {
        PlayerPrefs.SetInt(CurrentGamePlayFires, GetCurrentGamePlayFires() + 1);
    }

    public static void SubtractFromTotalFires(int coins)
    {
        PlayerPrefs.SetInt(TotelFires, GetTotalFires() - coins);
    }

    public static void SubtractSingleFire()
    {
        PlayerPrefs.SetInt(TotelFires, GetTotalFires() - 1);
    }

    public static void AddToTotalFires()
    {
        PlayerPrefs.SetInt(TotelFires, GetTotalFires() + GetCurrentGamePlayFires());
    }

    public static bool HasFire()
    {
        return GetTotalFires() > 0;
    }

    public static void ResetCurrentGamePlayFires()
    {
        PlayerPrefs.SetInt(CurrentGamePlayFires, 0);

    }

    public static void setTotelFires(int fires)
    {
        PlayerPrefs.SetInt(TotelFires, GetTotalFires() + fires);
        PlayerPrefs.Save();
    }


    public static void unLoackDragon(int index)
    {
        PlayerPrefs.SetInt("isDrago" + index + "Purchased", 1);
        PlayerPrefs.Save();
    }

    public static void SetUnLoackAllStatus(int status)
    {
        PlayerPrefs.GetInt("TotalCoins", 10000000);
        PlayerPrefs.SetInt("UnLoackAll", status);
        PlayerPrefs.Save();
    }

    public static int getUnlockAll()
    {
        return PlayerPrefs.GetInt("UnLoackAll");
    }

    public static void setAnimUnloackStatus(int index, int status)
    {
        PlayerPrefs.SetInt("Animation" + index, status);
        PlayerPrefs.Save();
    }
    public static int getAnimUnloackStatus(int index)
    {
        return PlayerPrefs.GetInt("Animation" + index);
    }

    public static void setUnlimitedCoins()
    {
        PlayerPrefs.GetInt("TotalCoins", 10000000);
        PlayerPrefs.SetInt("unlimitedCoins", 1);
        PlayerPrefs.Save();
    }
    public static int getUnlimitedCoins()
    {
        return PlayerPrefs.GetInt("unlimitedCoins");
    }

}
