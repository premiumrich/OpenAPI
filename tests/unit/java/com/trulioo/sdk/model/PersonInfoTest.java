package com.trulioo.sdk.model;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.*;

public class PersonInfoTest {
    private PersonInfo personInfo;

    @BeforeEach
    public void beforeEach() {
        personInfo = new PersonInfo();
    }

    @Test
    public void testFirstGivenName() {
        String firstGivenName = "A";
        personInfo.setFirstGivenName(firstGivenName);

        assertEquals(firstGivenName, personInfo.getFirstGivenName());
        assertEquals(firstGivenName, new PersonInfo().firstGivenName(firstGivenName).getFirstGivenName());
    }

    @Test
    public void testMiddleName() {
        String middleName = "B";
        personInfo.setMiddleName(middleName);

        assertEquals(middleName, personInfo.getMiddleName());
        assertEquals(middleName, new PersonInfo().middleName(middleName).getMiddleName());
    }

    @Test
    public void testFirstSurName() {
        String firstSurName = "C";
        personInfo.setFirstSurName(firstSurName);

        assertEquals(firstSurName, personInfo.getFirstSurName());
        assertEquals(firstSurName, new PersonInfo().firstSurName(firstSurName).getFirstSurName());
    }

    @Test
    public void testSecondSurname() {
        String secondSurname = "D";
        personInfo.setSecondSurname(secondSurname);

        assertEquals(secondSurname, personInfo.getSecondSurname());
        assertEquals(secondSurname, new PersonInfo().secondSurname(secondSurname).getSecondSurname());
    }

    @Test
    public void testIsOLatin1Name() {
        String isOLatin1Name = "A B C D";
        personInfo.setIsOLatin1Name(isOLatin1Name);

        assertEquals(isOLatin1Name, personInfo.getIsOLatin1Name());
        assertEquals(isOLatin1Name, new PersonInfo().isOLatin1Name(isOLatin1Name).getIsOLatin1Name());
    }

    @Test
    public void testDayOfBirth() {
        Integer dayOfBirth = 15;
        personInfo.setDayOfBirth(dayOfBirth);

        assertEquals(dayOfBirth, personInfo.getDayOfBirth());
        assertEquals(dayOfBirth, new PersonInfo().dayOfBirth(dayOfBirth).getDayOfBirth());
    }

    @Test
    public void testMonthOfBirth() {
        Integer monthOfBirth = 9;
        personInfo.setMonthOfBirth(monthOfBirth);

        assertEquals(monthOfBirth, personInfo.getMonthOfBirth());
        assertEquals(monthOfBirth, new PersonInfo().monthOfBirth(monthOfBirth).getMonthOfBirth());
    }

    @Test
    public void testYearOfBirth() {
        Integer yearOfBirth = 2020;
        personInfo.setYearOfBirth(yearOfBirth);

        assertEquals(yearOfBirth, personInfo.getYearOfBirth());
        assertEquals(yearOfBirth, new PersonInfo().yearOfBirth(yearOfBirth).getYearOfBirth());
    }

    @Test
    public void testMinimumAge() {
        Integer minimumAge = 18;
        personInfo.setMinimumAge(minimumAge);

        assertEquals(minimumAge, personInfo.getMinimumAge());
        assertEquals(minimumAge, new PersonInfo().minimumAge(minimumAge).getMinimumAge());
    }

    @Test
    public void testGender() {
        String gender = "gender";
        personInfo.setGender(gender);

        assertEquals(gender, personInfo.getGender());
        assertEquals(gender, new PersonInfo().gender(gender).getGender());
    }

    @Test
    public void testAdditionalFields() {
        PersonInfoAdditionalFields additionalFields = new PersonInfoAdditionalFields().fullName("A B C D");
        personInfo.setAdditionalFields(additionalFields);

        assertEquals(additionalFields, personInfo.getAdditionalFields());
        assertEquals(additionalFields, new PersonInfo().additionalFields(additionalFields).getAdditionalFields());
    }

    @Test
    public void testEquals() {
        String firstGivenName = "A";
        PersonInfo personInfo1 = new PersonInfo().firstGivenName(firstGivenName);

        assertEquals(personInfo1, personInfo1);
        assertEquals(personInfo1, new PersonInfo().firstGivenName(firstGivenName));
        assertNotEquals(personInfo1, new PersonInfo().firstGivenName(firstGivenName + "1"));
        assertNotEquals(personInfo1, null);
    }

    @Test
    public void testHashcode() {
        String firstGivenName = "A";

        assertEquals(new PersonInfo().firstGivenName(firstGivenName).hashCode(),
                new PersonInfo().firstGivenName(firstGivenName).hashCode());
    }

    @Test
    public void testToString() {
        String firstGivenName = "A";

        assertEquals(new PersonInfo().firstGivenName(firstGivenName).toString(),
                new PersonInfo().firstGivenName(firstGivenName).toString());
    }
}
