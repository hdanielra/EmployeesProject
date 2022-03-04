import { Component, OnInit } from '@angular/core';
import { IEmployee } from 'src/app/interfaces/employees.interfaces';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  // styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  public employees: IEmployee[] = [];
  public employeesFiltered: IEmployee[] = [];
  public idEmployee: string = '';
  public page: number = 0;
  public search: string = '';
  public length: number = 0;


  // -------------------------------------------------------
  constructor(public employeeService:EmployeeService) {
  }
  // -------------------------------------------------------

  ngOnInit() {
    this.getEmployees();
  }


  // -------------------------------------------------------
  getEmployees(){
   this.employeeService.getEmployees()
    .subscribe(
      response => {
        // console.log(response);
        this.employees = response;
        this.employeesFiltered = this.employees
        this.length = response.length;
        console.log(this.employees);


      }
   );
 }


  prevPage(){
    if(this.page > 0){
      this.page -= 5;
    }
  }
  nextPage(){
    this.page += 5;
  }

  onSearch(search: string){
    this.page = 0;
    this.search = search;
  }

}
