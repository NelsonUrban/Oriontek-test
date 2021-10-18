import { ClientAddress } from './clientAddress.model';
import { Company } from './company.model';

export interface Customer {
  id: number;
  companyId: number;
  name: string;
  cellPhone: string;
  email: string;
  company: Company;
  clientAddress :ClientAddress[];
  isActive :boolean;
}
