using UnityEngine;
using System.Collections;
using System;

public class GameOverController : Controller, IGameOverController {

		private TextMesh textMeshRendererGameOver { get; set;}
		private SpriteRenderer spriteRendererReturn { get; set;}

		private IGameOverModel GameOverModel;
		private IGameOverViewPresenter GameOverViewPresenter;

		public GameOverController () : base() {
		}

		public override IModelView OnLoadPostContructor (IModelView modelView) {

			this.GameOverModel = (IGameOverModel) modelView.model;
			this.GameOverModel.Visible += (sender, args) => Debug.Log("Visible "+(IGameOverModel)sender);
			this.GameOverModel.Visible += OnVisible ;

			this.GameOverModel.Hidden += (sender, args) => Debug.Log("Hidden "+(IGameOverModel)sender);
			this.GameOverModel.Hidden += OnHidden ;

			GameOverViewPresenter = (IGameOverViewPresenter) modelView.viewPresenter;
		    this.textMeshRendererGameOver =  GameOverViewPresenter.GetComponentInChildren<TextMesh> ();
			this.spriteRendererReturn = GameOverViewPresenter.GetComponentInChildren<SpriteRenderer> ();

			this.Visibility(false);
			return modelView;
		}

		private void OnHidden(object sender, EventArgs args){
			var isVisible = ((IGameOverModel)sender).isVisible;
			this.Visibility(isVisible);
		}

		private void OnVisible (object sender, EventArgs args) {
			var isVisible = ((IGameOverModel)sender).isVisible;
			this.Visibility(isVisible);
		}

		private void Visibility(bool isVisible){
			this.spriteRendererReturn.gameObject.SetActive (isVisible);
		    this.textMeshRendererGameOver.gameObject.SetActive(isVisible);
		}

	public void Visible(){
		this.GameOverModel.isVisible = true;
	}

	public void Hidden(){
		this.GameOverModel.isVisible = false;
	}
}

