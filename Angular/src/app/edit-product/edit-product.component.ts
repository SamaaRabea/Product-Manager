import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../model/product';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.scss'],
})
export class EditProductComponent implements OnInit {
  product!: any;
  ProductVersion!:any;
  // items!:[];
  productForm!: FormGroup;
  newProduct: any;
  constructor(private Api: ApiService, private route: ActivatedRoute,private router: Router) {}

  ngOnInit() {
    ////////////////creat form///////////////////
    this.CreatEditForm();

    ////////////////////get Product///////////////////////
    this.route.params.subscribe((params) => {
      this.Api.getItem(params['code']).subscribe((item: any) => {
        this.product = item;
      });
    });
  }

  CreatEditForm() {
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
  }

  updateProduct() {
      this.Api.EditProduct(this.product).subscribe({
        next: (res) => {
          // alert('product updated successfully');
        },
        error: () => {
          // alert('error while updating product');
        },

    })
    this.productForm.reset();
    this.router.navigate(['']);
    console.log(this.product);
  }
}
