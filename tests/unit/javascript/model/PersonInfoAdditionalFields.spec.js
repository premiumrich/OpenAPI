import expect from 'expect';
import PersonInfoAdditionalFields from '../../src/model/PersonInfoAdditionalFields';

describe('PersonInfoAdditionalFields', () => {
  it('should construct an instance of PersonInfoAdditionalFields', () => {
    const personInfoAdditionalFields = PersonInfoAdditionalFields.constructFromObject({}, undefined);

    expect(personInfoAdditionalFields).toBeInstanceOf(PersonInfoAdditionalFields);
  });

  it('should not construct with no data', () => {
    const personInfoAdditionalFields = PersonInfoAdditionalFields.constructFromObject(undefined, null);

    expect(personInfoAdditionalFields).toBe(null);
  });

  it('should construct with properties from object', () => {
    const data = {
      FullName: 'A B C',
    };
    const personInfoAdditionalFields = PersonInfoAdditionalFields.constructFromObject(data);

    expect(personInfoAdditionalFields.FullName).toBe(data.FullName);
  });
});
