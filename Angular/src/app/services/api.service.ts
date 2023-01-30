import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../model/product';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private http: HttpClient) {}
  getAllProducts() {
    return this.http.get('https://localhost:7157/api/Products');
  }
  getItem(code: string) {
    return this.http.get('https://localhost:7157/api/Products/GetByCode/' + code);
  }
  deleteProduct(code: string) {
    return this.http.delete('https://localhost:7157/api/Products/' + code);
  }
  AddNewProduct(product:Product){
    // const headers = new HttpHeaders().set('Content-Type', 'application/json');
    // return this.http.post('https://localhost:7157/api/Products', product);
    return this.http.post('https://localhost:7157/api/Products',product)
  }
  EditProduct(product:Product){
    return this.http.put('https://localhost:7157/api/Products', product);
  }
}
