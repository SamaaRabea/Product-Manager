import { Component, OnInit, Pipe, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from '../model/product';
import { ApiService } from '../services/api.service';
import { filter } from 'rxjs/operators';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
  products!: any;
  filteredData!: any;
  searchTerm: String = '';

  constructor(private Api: ApiService ,private alertify:AlertifyService) {}
  ngOnInit() {
    this.getallProduct();
  }

  search() {
    this.filteredData = this.products.filter((item: { name: string }) =>
      item.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  getallProduct() {
    this.Api.getAllProducts().subscribe((data) => {
      this.products = data;
      this.filteredData = this.products;
    });
  }
  
  deleteProduct(code: string) {
    this.Api.deleteProduct(code).subscribe({
      next: (res) => {
        this.alertify.success('Product Delete Successfully');
        this.getallProduct();
      },
      error: () => {
        this.alertify.error('error while deleting product');
      }
     })
    }
}
