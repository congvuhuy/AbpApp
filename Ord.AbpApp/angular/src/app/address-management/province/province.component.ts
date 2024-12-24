import { Component, OnInit } from '@angular/core';
import { ProvinceService } from '../../core/services/province-service.service';
import { NzCardComponent } from 'ng-zorro-antd/card';
import { NzOptionComponent, NzSelectComponent } from 'ng-zorro-antd/select';
import { NzFloatButtonTopComponent } from 'ng-zorro-antd/float-button';

@Component({
  selector: 'app-province',
  standalone: true,
  imports: [
    NzCardComponent,
    NzSelectComponent,
    NzOptionComponent,
    NzFloatButtonTopComponent
  ],
  templateUrl: './province.component.html',
  styleUrl: './province.component.scss'
})
export class ProvinceComponent implements OnInit{
    provinces:[]=[]
    provinceForm: any;
    isModalVisible: any;
  selectedProvince: any;
  selectedDistrict: any;
    constructor(private _provinceService :ProvinceService) {
    }

    ngOnInit(): void {
      this._provinceService.getProvinces("",0,10).subscribe(
        res=>{
          console.log(res);
          this.provinces=res.items;
        }
      )
    }


  editProvince(province) {

  }

  deleteProvince(id) {

  }

  onProvinceChange($event: any) {

  }

  onDistrictChange($event: any) {

  }

  openAddProvinceModal() {

  }
}
