import { Injectable } from '@angular/core';
import { IEmployee, IEmployeeByIdResponse, IEmployeesResponse } from '../interfaces/employees.interfaces';
import { HttpClient } from '@angular/common/http';
import { map } from "rxjs/operators";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {


  // ------------------------------------------------------------
  myAppUrl: string = 'https://localhost:44368/';
  myApiUrl: string = 'api/Employees/';
  // ------------------------------------------------------------


  // ............................................................
  constructor(private _http:HttpClient) { }
  // ............................................................



  // -----------------------------------------------------------------
  getEmployees(): Observable<IEmployee[]>{
    return this._http.get<IEmployeesResponse>(this.myAppUrl + this.myApiUrl)
    .pipe(
      map( this.transformEmployeeResponse )
    );
  }
  // -----------------------------------------------------------------

  transformEmployeeResponse(resp: IEmployeesResponse): IEmployee[]{
    if(resp){
      const employeeList: IEmployeesResponse = resp as IEmployeesResponse;
      return employeeList.Data;
    }else{
       return null;
    }
  }
  // -----------------------------------------------------------------





  // -----------------------------------------------------------------
  getEmployeeById(): Observable<IEmployee>{
    return this._http.get<IEmployeeByIdResponse>(this.myAppUrl + this.myApiUrl)
    .pipe(
      map( this.transformEmployeeByIdResponse )
    );
  }
  // -----------------------------------------------------------------

  transformEmployeeByIdResponse(resp: IEmployeeByIdResponse): IEmployee{
    if(resp){
      const employeeList: IEmployeeByIdResponse = resp as IEmployeeByIdResponse;
      return employeeList.Data;
    }else{
       return null;
    }
  }
  // -----------------------------------------------------------------

}
