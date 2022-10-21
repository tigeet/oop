namespace Isu.Extra.Utils;
public static class Utils
{
    public static bool IsValidGroupName(string groupName)
    {
        // X[3-5]1XX for 1st course, else X[3-5][2-5]XXX
        string allowedFacultyChars = "ABCDFKLMNPRTUVWXYZ";
        string allowedTypeDigits = "345";
        string allowedCourseNumberDigits = "12345";
        string allowedGroupNumberDigits = "0123456789";

        if (groupName.Length != 5 && groupName.Length != 6)
            return false;

        if (!allowedFacultyChars.Contains(groupName[0]))
            return false;

        if (!allowedTypeDigits.Contains(groupName[1]))
            return false;

        if (!allowedCourseNumberDigits.Contains(groupName[2]))
            return false;

        if (groupName[2] == '1' && groupName.Length != 5)
            return false;

        if (!allowedGroupNumberDigits.Contains(groupName[3]) || !allowedGroupNumberDigits.Contains(groupName[4]))
            return false;

        if (groupName.Length == 6 && !allowedGroupNumberDigits.Contains(groupName[5]))
            return false;

        return true;
    }
}
