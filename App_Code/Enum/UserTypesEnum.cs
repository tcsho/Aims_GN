using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserTypesEnum
/// </summary>
public enum UserTypesEnum
{
    TR = 1,
    Admin = 2,
    CO = 3,
    RO = 4,
    HO = 5,
    APG = 8,
    ML = 11,
    SAdmin = 16,
    OT = 17,
    LIB = 19,
    RD = 20,
    ST = 21,
    HOA = 22,
    HOI = 23,
    HOET = 24,
    ROA = 25,
    ROI = 26,
    AT = 27,
    CH = 28,
    S_HO = 29,
    Ro_Academic = 30,
    NO = 31

}
public enum AdmissionClasses
{
    Olevel1=14,
    Olevel2=15,
    Matric1=16,
    Matric2=17,
    Matric=18, 
    A1=19,
    A2=20,
    Class9=13

}
public enum SubjectList
{
    UrduJr=12,
    Science=14,
    Business=0, 
    PakStudies=131, 
    Islamiat=132, 
    Urdu=133, 
    Math=134, 
    English=135, 
    MaxCompSuject=131,
    MinCompSuject = 136
}
public enum SubjectRestrictions
{
    OlevelSubjectTaken=8,
    OlevelSubjectIntended=3, 
    MinAlevelSubject=3
}