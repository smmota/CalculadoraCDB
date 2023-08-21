import { Component, OnInit } from '@angular/core';
import { Aplicacao } from '../shared/aplicacao';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AplicacaoRequest } from '../shared/aplicacao-request';
import { AplicacaoService } from '../service/aplicacao-service';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.css']
})
export class FormularioComponent implements OnInit {
  formAplicacao!: FormGroup;
  aplicacaoRequest: AplicacaoRequest = new AplicacaoRequest();
  aplicacao: Aplicacao = new Aplicacao();

  constructor(private formBuilder: FormBuilder,
              private aplicacaoService: AplicacaoService) { }

  ngOnInit(): void {
    this.creatForm(new Aplicacao());
  }

  creatForm(aplicacao: Aplicacao) {
    this.formAplicacao = this.formBuilder.group({
        valorAplicacao: [aplicacao.valorAplicacao],
        prazo: [aplicacao.prazo],
        valorBruto: [aplicacao.valorBruto],
        valorLiquido: [aplicacao.valorLiquido]
    });
  }

  onSubmit() {
    
    this.aplicacao = this.formAplicacao.value;

    if(Number(this.aplicacao.valorAplicacao) == 0) {
      alert("O valor da aplicação não pode ser 0.");
      return;
    }

    if(Number(this.aplicacao.prazo) <= 1) {
      alert("O prazo dever se maior que 1.");
      return;
    }

    this.aplicacaoRequest.valorAplicado = this.aplicacao.valorAplicacao;
    this.aplicacaoRequest.quantidadeMeses = this.aplicacao.prazo;

    this.aplicacaoService.calcular(this.aplicacaoRequest).subscribe(res => {
      
      this.aplicacao.valorAplicacao = res.valorAplicado;
      this.aplicacao.valorAplicacao = res.valorAplicado;
      this.aplicacao.prazo = res.quantidadeMeses;
      this.aplicacao.valorBruto = res.valorBruto;
      this.aplicacao.valorLiquido = res.valorLiquido;
      this.creatForm(this.aplicacao);
    }, httpError => {
      console.log(httpError)
    })
  }
}
