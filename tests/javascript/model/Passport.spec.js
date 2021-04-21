import expect from 'expect';
import Passport from '../../src/model/Passport';

describe('Passport', () => {
  it('should construct an instance of Passport', () => {
    const passport = Passport.constructFromObject({}, undefined);

    expect(passport).toBeInstanceOf(Passport);
  });

  it('should not construct with no data', () => {
    const passport = Passport.constructFromObject(undefined, null);

    expect(passport).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Mrz1: '<<test1>>',
      Mrz2: '<<test2>>',
      Number: '123',
      DayOfExpiry: 15,
      MonthOfExpiry: 9,
      YearOfExpiry: 2020,
    };
    const passport = Passport.constructFromObject(data);

    expect(passport.Mrz1).toBe(data.Mrz1);
    expect(passport.Mrz2).toBe(data.Mrz2);
    expect(passport.Number).toBe(data.Number);
    expect(passport.DayOfExpiry).toBe(data.DayOfExpiry);
    expect(passport.MonthOfExpiry).toBe(data.MonthOfExpiry);
    expect(passport.YearOfExpiry).toBe(data.YearOfExpiry);
  });
});
