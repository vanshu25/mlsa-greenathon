import React from 'react';


import { CreateBusiness } from '../services/api';
import { Formik, Field, Form, ErrorMessage } from "formik";
import * as Yup from 'yup';

import countries from '../assets/static/iso_countries.json';

const FormSchema = Yup.object().shape({
  name: Yup.string()
    .min(2)
    .max(50)
    .required(),

  address: Yup.string()
    .min(2)
    .max(50)
    .required(),

  industry: Yup.string()
    .min(2)
    .max(50)
    .required(),

  country: Yup.string()
    .min(2)
    .max(50)
    .required(),

  mission: Yup.string()
    .min(2)
    .max(50)
    .required(),
});

const initialValues: CreateBusiness = {
  name: '',
  addressLine: '',
  town: '',
  industry: '',
  zipCode: '',
  countryIsoCode: '',
  logo: new Blob(),
  missionStatement: ''
};

const SubmitBusinessForm = (props = { onSubmitForm: (payload: CreateBusiness) => { } }) => {
  return (
    <div>
      <Formik initialValues={initialValues}
        validationSchema={FormSchema}
        onSubmit={values => {
          props.onSubmitForm({
            ...values
          })
        }}
      >
        <Form>
          <div className="heading">
            <span className="label">Add a business</span>
          </div>

          <div>
            <div className="input">
              <label htmlFor="name" className="label">Name</label>
              <Field name="name" id="name" type="text" />
              <ErrorMessage name="name" />
            </div>

            <div className="input">
              <label htmlFor="addressLine" className="label">Address</label>
              <Field name="addressLine" id="addressLine" type="text" />
              <ErrorMessage name="addressLine" />
            </div>

            <div className="input">
              <label htmlFor="town" className="label">Address</label>
              <Field name="town" id="town" type="text" />
              <ErrorMessage name="town" />
            </div>

            <div className="input">
              <label htmlFor="zipCode" className="label">Address</label>
              <Field name="zipCode" id="zipCode" type="text" />
              <ErrorMessage name="zipCode" />
            </div>

            <div className="input">
              <label htmlFor="industry" className="label">Industry</label>
              <Field name="industry" id="industry" type="text" />
              <ErrorMessage name="industry" />
            </div>

            <div className="input">
              <label htmlFor="countryIsoCode" className="label">Country</label>
              <select name="countryIsoCode">
                {countries.map(x => <option key={x.code} value={x.code}>{x.name}</option>)}
              </select>
              <ErrorMessage name="countryIsoCode" />
            </div>

            <div className="input">
              <label htmlFor="logo" className="label">Upload your logo</label>
              <input name="logo" id="logo" type="file" />
              <ErrorMessage name="logo" />
            </div>

            <div className="input">
              <label htmlFor="missionStatement" className="label">Mission statement</label>
              <Field name="missionStatement" id="missionStatement" type="text" />
              <ErrorMessage name="missionStatement" />
            </div>
          </div>

          <button type="submit">Submit</button>
        </Form>
      </Formik>
    </div>
  );
};

export default SubmitBusinessForm;