import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressManagementRoutingModule } from './address-management-routing.module';
import { NzSelectModule } from 'ng-zorro-antd/select';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AddressManagementRoutingModule,
    NzSelectModule
  ]
})
export class AddressManagementModule { }
