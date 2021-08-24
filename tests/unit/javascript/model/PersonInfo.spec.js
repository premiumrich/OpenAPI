import expect from 'expect';
import PersonInfo from '../../src/model/PersonInfo';
import PersonInfoAdditionalFields from '../../src/model/PersonInfoAdditionalFields';

describe('PersonInfo', () => {
  it('should construct an instance of PersonInfo', () => {
    const personInfo = PersonInfo.constructFromObject({}, undefined);

    expect(personInfo).toBeInstanceOf(PersonInfo);
  });

  it('should not construct with no data', () => {
    const personInfo = PersonInfo.constructFromObject(undefined, null);

    expect(personInfo).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      FirstGivenName: 'A',
      MiddleName: 'B',
      FirstSurName: 'C',
      SecondSurname: 'D',
      ISOLatin1Name: 'A B C',
      DayOfBirth: 15,
      MonthOfBirth: 9,
      YearOfBirth: 2020,
      MinimumAge: 18,
      Gender: 'gender',
      AdditionalFields: PersonInfoAdditionalFields.constructFromObject({ FullName: 'A B C' }),
    };
    const personInfo = PersonInfo.constructFromObject(data);

    expect(personInfo.FirstGivenName).toBe(data.FirstGivenName);
    expect(personInfo.MiddleName).toBe(data.MiddleName);
    expect(personInfo.FirstSurName).toBe(data.FirstSurName);
    expect(personInfo.SecondSurname).toBe(data.SecondSurname);
    expect(personInfo.ISOLatin1Name).toBe(data.ISOLatin1Name);
    expect(personInfo.DayOfBirth).toBe(data.DayOfBirth);
    expect(personInfo.MonthOfBirth).toBe(data.MonthOfBirth);
    expect(personInfo.YearOfBirth).toBe(data.YearOfBirth);
    expect(personInfo.MinimumAge).toBe(data.MinimumAge);
    expect(personInfo.Gender).toBe(data.Gender);
    expect(personInfo.AdditionalFields).toStrictEqual(data.AdditionalFields);
  });
});
