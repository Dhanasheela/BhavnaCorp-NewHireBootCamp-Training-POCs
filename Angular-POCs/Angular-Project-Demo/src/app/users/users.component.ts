import { Component, OnInit } from '@angular/core';
type User = Array<{ id: number; name: string;gender:string;address:string }>;
@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  
userslist:User=[
  { id:1,name:"dhanu",gender:"female",address:"India" },
  {id:2,name:"Rak",gender:"male",address:"UK" },
   {id:3,name:"Uma",gender:"female",address:"Srilanka" },
  {id:4,name:"mani",gender:"male",address:"Australia" },
  {id:5,name:"sony",gender:"female",address:"USA" },
  {id:6,name:"Ruthvik",gender:"male",address:"Italy" },

];

  constructor() { }

  ngOnInit(): void {
  }

}
