import React from 'react';

import { Formik, Field, Form } from "formik";
import * as Yup from 'yup';

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

  logo: Yup.string()
    .min(2)
    .max(50)
    .required(),

  mission: Yup.string()
    .min(2)
    .max(50)
    .required(),
});

const initialValues = {
  name: '',
  address: '',
  industry: '',
  country: '',
  logo: '',
  mission: ''
};

const SubmitBusinessForm = () => {
  return (
    <div>
      <Formik initialValues={initialValues}
        validationSchema={FormSchema}
        onSubmit={values => {
          // same shape as initial values
          console.log(values);
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
            </div>
            <div className="input">
              <label htmlFor="address" className="label">Address</label>
              <Field name="address" id="address" type="text" />
            </div>
            <div className="input">
              <label htmlFor="industry" className="label">Industry</label>
              <Field name="industry" id="industry" type="text" />
            </div>
            <div className="input">
              <label htmlFor="country" className="label">Country</label>
              <Field name="country" id="country" type="text" />
            </div>
            <div className="input">
              <label htmlFor="logo" className="label">Upload your logo</label>
              <Field name="logo" id="logo" type="text" />
            </div>
            <div className="input">
              <label htmlFor="mission" className="label">Mission statement</label>
              <Field name="mission" id="mission" type="text" />
            </div>
          </div>

          <button type="submit">Submit</button>
        </Form>
      </Formik>
    </div>
  );
};

export default SubmitBusinessForm;