import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class XPathBuilderService {

  private baseUrl: string;
  constructor(private httpClient: HttpClient) {
    this.baseUrl = "/sitecore/api/ssc/xpathbuilderspeak/query?sc_site=shell";

    
    
  }

  fetchItems(query: string, database: string, contextItemId: string) {
    return this.httpClient.post(this.baseUrl, { Database: database, Query: query, ContextItemId: contextItemId});
  }
}
