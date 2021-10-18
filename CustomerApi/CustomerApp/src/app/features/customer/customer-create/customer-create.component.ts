import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ClientAddress } from 'src/app/models/clientAddress.model';
import { Company } from 'src/app/models/company.model';
import { Customer } from 'src/app/models/customer.model';
import Swal from 'sweetalert2';
import { CompanyService } from '../../company/company.service';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-customer-create',
  templateUrl: './customer-create.component.html',
  styleUrls: ['./customer-create.component.css']
})
export class CustomerCreateComponent implements OnInit {

  customerForm: FormGroup |any;
  companies: Company[] | undefined;
  addressDetails: ClientAddress[] = new Array<ClientAddress>();
  submitted = false;

  constructor(
    private customerService: CustomerService,
    private companyService: CompanyService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.customerForm = this.formBuilder.group({
      ID: 0,
      companyId:['', Validators.required],
      name: [
        '',
        Validators.compose([Validators.required, Validators.maxLength(50)]),
      ],     
      cellPhone: [
        '',
        Validators.compose([Validators.required, Validators.maxLength(14)]),
      ],
      email: [
        '',
        Validators.compose([Validators.required, Validators.maxLength(100)]),
      ] ,
      clientAddress :this.formBuilder.array([this.createClientAddress]),
      Address :'',
    });

    this.getCompanies();
  }
  createClientAddress()
 {
    return this.formBuilder.group({
      id: new FormControl({ value: '' }),
      description: new FormControl({ value: '' }),
    })   
 }

 createAddress()
 {
   if( this.customerForm.value.Address == null ||this.customerForm.value.Address == '' )
   {
      Swal.fire({
        title: '',
        text: 'No puedes agregar una direccion cuando el campo esta vacío.', 
      })
      return;
   }
     this.addressDetails.push ({
      id:0,
      description : this.customerForm.value.Address,
      isActive :true
     });
 }
 deleteAddress( index : number)
 {
    this.addressDetails.splice(index,1)
 }

  getCompanies(){
    this.companyService.getAll().subscribe(
      (response) => (this.companies = response),
      (err) => {
        Swal.fire('Error', err.error.errors[0].message, 'error');
      }
    ),
      () => console.log(this.companies);
  }

  get formControl() {
    return this.customerForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    if (this.customerForm.invalid) {
      return;
    }

    this.create();
  }

  create() {    
    let customer: Customer = Object.assign({}, this.customerForm.value);
       customer.clientAddress = this.addressDetails;
    this.customerService.create(customer).subscribe(
      () => {
        this.onSaveSuccess();
      },
      (err) => {
        Swal.fire('Error', err.error.errors[0].message, 'error');
      }
    );
  }

  onSaveSuccess() {
    Swal.fire({
      title: '',
      text: 'Registro guardado correctamente.',
      icon: 'success',
      showCancelButton: false,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Ok!',
    }).then((result) => {
      if (result.value) {
        this.router.navigate(['../customer']);
      }
    });
  }

  backToList() {
    this.customerForm.reset();
    this.router.navigate(['../customer']);
  }
}
