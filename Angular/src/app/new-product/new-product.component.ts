import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertifyService } from '../services/alertify.service';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.scss'],
})
export class NewProductComponent implements OnInit {
  productForm!: FormGroup;
  product!: any;
  userSubmited!: boolean;
  actionButton: string = 'Save';
  VersionsForm!: FormGroup;
  versions:any;
  product_VersionList:any;
  constructor(
    private router: Router,
    private alertify: AlertifyService,
    private Api: ApiService
  ) {}

  ngOnInit() {
    this.CreatRegisterationForm();
    this.product_VersionList = [];
  }

  CreatRegisterationForm() {
    this.productForm = new FormGroup({
      code: new FormControl(null, [
        Validators.required,
        Validators.minLength(5),
      ]),
      name: new FormControl('', [Validators.required]),
      versionNum: new FormControl('', Validators.required),
      revisionNum: new FormControl('', Validators.required),
      versionDate: new FormControl('', Validators.required),
      editDate: new FormControl(''),
      nextRevieweDate: new FormControl(''),
      editBy: new FormControl(''),
      reviewedBy: new FormControl(''),
      approvedBy: new FormControl(''),
      product_Versions: new FormGroup({
        itemNo: new FormControl(''),
        versionDate: new FormControl(''),
      }),
    });

    this.VersionsForm=new FormGroup({
      itemNo: new FormControl(''),
      versionDate: new FormControl(''),
    })
  }

  onSubmit() {
    this.userSubmited = true;
    if (this.productForm.valid) {
      this.product = this.productForm.value;
      this.product.versionDate = new Date(this.product.versionDate).toISOString();
      this.product.editDate = new Date(this.product.editDate).toISOString();
      this.product.nextRevieweDate = new Date(this.product.nextRevieweDate).toISOString();

      this.product.product_Versions=this.product_VersionList

      this.Api.AddNewProduct(this.product).subscribe((res) => {
        console.log(res);
      });

      this.userSubmited = false;
      this.alertify.success('Congrates, you are successfully registered');
      this.productForm.reset();
      this.router.navigate(['']);
    } else {
      this.alertify.error('Kindly provide the required fields');
    }
  }
  onSubmitsmallForm(){
    this.versions = this.VersionsForm.value;
    this.versions.versionDate = new Date(this.versions.versionDate).toISOString();
    this.product_VersionList.push(this.versions);
    this.VersionsForm.reset()
  }
  deleteItem(item:any){
    for(let i=0;i<this.product_VersionList.length;i++){
      if(this.product_VersionList[i]==item){
        this.product_VersionList.splice(i, 1);
      }
    }
  }
  ////////////////////////////////////////////////////////////////////////
  //getter methods for all form controlers
  ///////////////////////////////////////////////////////////////////////
  get code() {
    return this.productForm.get('code');
  }
  get name() {
    return this.productForm.get('name');
  }
  get versionNum() {
    return this.productForm.get('versionNum');
  }
  get revisionNum() {
    return this.productForm.get('revisionNum');
  }
  get versionDate() {
    return this.productForm.get('versionDate');
  }
  get editDate() {
    return this.productForm.get('editDate');
  }
  get nextRevieweDate() {
    return this.productForm.get('nextReviewDate');
  }
  get editBy() {
    return this.productForm.get('editBy');
  }
  get reviewedBy() {
    return this.productForm.get('reviewedBy');
  }
  get approvedBy() {
    return this.productForm.get('versionDate');
  }
}
