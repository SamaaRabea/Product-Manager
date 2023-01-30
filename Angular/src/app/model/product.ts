import { ProductVersion } from "./ProductVersion";

export interface Product {
  code: string;
  name: string;
  versionNum: number;
  revisionNum: number;
  versionDate: Date;
  editDate: Date;
  nextRevieweDate: Date;
  editBy: string;
  reviewedBy: string;
  approvedBy: string;
  product_Versions:any;
}
