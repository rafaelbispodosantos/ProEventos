import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from 'src/app/helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  private validation(): void {


  }
  userForm: FormGroup;
  nomeCtrl: FormControl;
  ultimoNomelCtrl: FormControl;
  emailCtrl: FormControl;
  usuarioCtrl: FormControl;
  senhaCtrl: FormControl;
  confirmarSenhaCtrl: FormControl;

constructor(fb: FormBuilder) {

this.nomeCtrl = fb.control('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]);
this.ultimoNomelCtrl = fb.control('', Validators.required);
this.emailCtrl = fb.control('', [Validators.required, Validators.email]);
this.usuarioCtrl = fb.control('', [Validators.required, Validators.maxLength(2000)]);
this.senhaCtrl = fb.control('', [Validators.required, Validators.maxLength(12)]);
this.confirmarSenhaCtrl = fb.control('', [Validators.required]);
this.userForm = fb.group({
nome: this.nomeCtrl,
ultimoNome: this.ultimoNomelCtrl,
email: this.emailCtrl,
usuario: this.usuarioCtrl,
senha: this.senhaCtrl,
confirmarSenha: this.confirmarSenhaCtrl,
});
}

ngOnInit(): void {

}
register(): void {
console.log(this.userForm.value);
}

}
