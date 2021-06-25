import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-eventos-detalhe',
  templateUrl: './eventos-detalhe.component.html',
  styleUrls: ['./eventos-detalhe.component.css']
})
export class EventosDetalheComponent implements OnInit {
  userForm: FormGroup;
temaCtrl: FormControl;
localCtrl: FormControl;
dataCtrl: FormControl;
qtdPessoasCtrl: FormControl;
telefoneCtrl: FormControl;
emailCtrl: FormControl;
constructor(fb: FormBuilder) {
this.temaCtrl = fb.control('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]);
this.localCtrl = fb.control('', Validators.required);
this.dataCtrl = fb.control('', Validators.required);
this.qtdPessoasCtrl = fb.control('', [Validators.required, Validators.maxLength(2000)]);
this.telefoneCtrl = fb.control('', [Validators.required, Validators.maxLength(12)]);
this.emailCtrl = fb.control('', [Validators.required, Validators.email]);
this.userForm = fb.group({
tema: this.temaCtrl,
local: this.localCtrl,
data: this.dataCtrl,
qtdPessoa: this.qtdPessoasCtrl,
telefone: this.telefoneCtrl,
email: this.emailCtrl,
});
}

ngOnInit(): void {

}
register(): void {
console.log(this.userForm.value);
}

public resetForm(): void {
  this.userForm.reset();
}

}







