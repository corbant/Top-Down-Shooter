using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class Dialogue : FluentScript {

	public GameObject input;
	public UnityEngine.UI.Text name;

    public override void OnFinish()
    {
        GameManager.instance.isDialogueShowing = false;
		Player.instance.canMove = true;
    }

    public override void OnStart()
    {
        GameManager.instance.isDialogueShowing = true;
		Player.instance.canMove = false;
		Player.instance.canShoot = false;
    }

	void playerMove(bool Bool)
	{
		Player.instance.canMove = Bool;
	}
	void shoot(bool Bool) {
		Player.instance.canShoot = Bool;
	}
	void getName() {
		input.SetActive(true);
		while (!Input.GetButtonDown("Submit")) {

		}
		GameManager.instance.playerName = name.text;
		input.SetActive(false);
		Destroy(input);
	}


	public override FluentNode Create()
	{
		return
			Show() *
			Write("[Instructor]: Welcome to training. My name is Carl and I will be your instructor today.").WaitForButton() *
			Write("[Carl]: Today we will work on learning the basics of the ship's controls. First off, you need to learn the basics of moving.").WaitForButton() *
			Write("[Carl]: To move, simply use the arrow keys on the keyboard corrisponding to the direction you want to go. Try it!") *
			Do(() => playerMove(true)) *
			Hide() *
			Write(5, "") *
			Do(() => playerMove(false)) *
			Show() *
			Write("[Carl]: Great! One more control: press and hold space to fire your guns.") *
			Do(() => playerMove(true)) *
			Do(() => shoot(true)) *
			Hide() *
			Write(5, "") *
			Do(() => playerMove(false)) *
			Do(() => shoot(true)) *
			Show() *
			Write("[Carl]: Awesome! Now I think you are ready to test your skills in the real world...") *
            Write("[Mission Control]: Enemies incoming. Permission to engage.").WaitForButton() *
            Write("[Carl]: Perfect timeing. Get ready for a test of your skills!").WaitForButton() *
			Hide();


	}
}
