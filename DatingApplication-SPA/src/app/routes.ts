import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { AuthService } from './_services/auth.service';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    // this dummy rote has been added to demonstrate appliying ruteguard at single place.
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'members', component: MemberListComponent },
      { path: 'messages', component: MessagesComponent },
      { path: 'lists', component: ListsComponent }
    ]
  },
  // { path: 'members', component: MemberListComponent, canActivate: [AuthGuard]},
  // { path: 'messages', component: MessagesComponent},
  // { path: 'lists', component: ListsComponent},
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
