import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../model/product';
import { ProductVersion } from '../model/ProductVersion';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit{
  product!:any;
  ProductVersion!:any;
  items!:[];
  constructor(private Api: ApiService,private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe((params => {
      this.Api.getItem(params["code"]).subscribe((item: any) => {
        this.product = item;
        this.ProductVersion=this.product.product_Versions
        console.log(this.product)
      });
    }))
  }

}
