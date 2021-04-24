import axios from 'axios';

const endpoint = 'https://mlsa-greenathon.azurewebsites.net/api';

export interface Business {
  name: string
}

export const queryBusiness = (params: any): Promise<Business[]> =>
  axios.get(endpoint + '/QueryBusinesses', { params });