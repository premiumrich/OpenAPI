import expect from 'expect';
import DriverLicence from '../../src/model/DriverLicence';

describe('DriverLicence', () => {
  it('should construct an instance of DriverLicence', () => {
    const driverLicence = DriverLicence.constructFromObject({}, undefined);

    expect(driverLicence).toBeInstanceOf(DriverLicence);
  });

  it('should not construct with no data', () => {
    const driverLicence = DriverLicence.constructFromObject(undefined, null);

    expect(driverLicence).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      Number: '123',
      State: 'CA',
      DayOfExpiry: 15,
      MonthOfExpiry: 9,
      YearOfExpiry: 2020,
    };
    const driverLicence = DriverLicence.constructFromObject(data);

    expect(driverLicence.Number).toBe(data.Number);
    expect(driverLicence.State).toBe(data.State);
    expect(driverLicence.DayOfExpiry).toBe(data.DayOfExpiry);
    expect(driverLicence.MonthOfExpiry).toBe(data.MonthOfExpiry);
    expect(driverLicence.YearOfExpiry).toBe(data.YearOfExpiry);
  });
});
