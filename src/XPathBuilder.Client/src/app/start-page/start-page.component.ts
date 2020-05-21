import { Component, OnInit, ValueProvider } from '@angular/core';
import { XPathBuilderService } from '../xpathbuilder.service';
import { ItemModel, ItemWebApiResult } from '../models';
import { SciLogoutService } from '@speak/ng-sc/logout';

@Component({
  selector: 'app-start-page',
  templateUrl: './start-page.component.html',
  styleUrls: ['./start-page.component.scss']
})
export class StartPageComponent implements OnInit {

  isNavigationShown: boolean;
  isActive: boolean;
  isEditing = false;
  itemWebApiResponse: ItemWebApiResult;
  query = '';
  displayTree: boolean;
  selectedDatabase = "master";
  databases = ["master", "core", "web"];
  isLoading: boolean;
  queryResult: any;
  errorMessage: string;

  constructor(private xPathBuilderService: XPathBuilderService, public logoutService: SciLogoutService) {
    this.displayTree = false;
  }

  ngOnInit() {
    this.initTreeLoad();
  }

  reloadTree() {
    this.initTreeLoad();
  }

  initTreeLoad() {
    var result = this.xPathBuilderService.fetchItems('/sitecore/*', this.selectedDatabase, null).subscribe({
      next: response => {
        console.log(response);
        this.itemWebApiResponse = response as ItemWebApiResult;
        this.selectedItem = this.itemWebApiResponse.Items[0];
      }
    });
  }

  loadTree() {
    if (this.displayTree) {
      this.displayTree = false;
    }
    else {
      this.displayTree = true;
    }
  }

  loadChildren(item: ItemModel) {

    if (item.State == "expanded") {
      item.State = "";
      item.Children = null;
      return;
    }
    item.State = "expanded";

    var result = this.xPathBuilderService.fetchItems('./*', this.selectedDatabase, item.ID).subscribe({
      next: response => {
        var itemWebApiResponse = response as ItemWebApiResult;
        item.Children = itemWebApiResponse.Items;
      }
    });
  }

  selectedItem: ItemModel;
  loadData(item: ItemModel) {
    this.selectedItem = item;
    this.displayTree = false;
  }

  checkState(item: ItemModel) {
    if (item.State && item.State == "expanded") {
      return true;
    }
    return false;
  }

  queryItems() {
    this.errorMessage = null;
    this.isLoading = true;
    var result = this.xPathBuilderService.fetchItems(this.query, this.selectedDatabase, this.selectedItem.ID)
      .subscribe(
        {
          next: response => {
            var itemWebApiResponse = response as ItemWebApiResult;
            this.queryResult = itemWebApiResponse;
            this.isLoading = false;
          },
          error: error => {
            console.log(error);
            this.isLoading = false;
            this.errorMessage = "An error occured, check the browser's console for more details.";
          }
        });
  }
}
