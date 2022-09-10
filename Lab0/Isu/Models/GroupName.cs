using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Isu.Models;

public class GroupName {
  private string groupName;
  // private CourseNumber courseNumber;


  public GroupName(string groupName) {
    ValidateName(groupName);
    this.groupName = groupName;
    // this.courseNumber = new CourseNumber(groupName);
  }


  public string GetGroupName() {
    return this.groupName;
  }


  private void ValidateName(string _groupName) {
    const string pattern = @"[ABCDFKLMNPRTUVWXYZ][3-5][0-9]\d\d\d?c?";
    MatchCollection matches = Regex.Matches(_groupName, pattern, RegexOptions.IgnorePatternWhitespace);

    if (matches.Count == 0)
      throw new Exception(); //extract to class
  }
}
