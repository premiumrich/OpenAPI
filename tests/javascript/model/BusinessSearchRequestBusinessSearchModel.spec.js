import expect from 'expect';
import BusinessSearchRequestBusinessSearchModel from '../../src/model/BusinessSearchRequestBusinessSearchModel';
import Location from '../../src/model/Location';

describe('BusinessSearchRequestBusinessSearchModel', () => {
  it('should construct an instance of BusinessSearchRequestBusinessSearchModel', () => {
    const businessSearchRequestBusinessSearchModel = BusinessSearchRequestBusinessSearchModel.constructFromObject(
      {},
      undefined
    );

    expect(businessSearchRequestBusinessSearchModel).toBeInstanceOf(BusinessSearchRequestBusinessSearchModel);
  });

  it('should not construct with no data', () => {
    const businessSearchRequestBusinessSearchModel = BusinessSearchRequestBusinessSearchModel.constructFromObject(
      undefined,
      null
    );

    expect(businessSearchRequestBusinessSearchModel).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      BusinessName: 'test',
      Website: 'https://trulioo.com',
      JurisdictionOfIncorporation: 'Alberta',
      DUNSNumber: '123',
      Location: Location.constructFromObject({ BuildingNumber: '10' }),
    };
    const businessSearchRequestBusinessSearchModel = BusinessSearchRequestBusinessSearchModel.constructFromObject(data);

    expect(businessSearchRequestBusinessSearchModel.BusinessName).toBe(data.BusinessName);
    expect(businessSearchRequestBusinessSearchModel.Website).toBe(data.Website);
    expect(businessSearchRequestBusinessSearchModel.JurisdictionOfIncorporation).toBe(data.JurisdictionOfIncorporation);
    expect(businessSearchRequestBusinessSearchModel.DUNSNumber).toBe(data.DUNSNumber);
    expect(businessSearchRequestBusinessSearchModel.Location).toStrictEqual(data.Location);
  });
});
