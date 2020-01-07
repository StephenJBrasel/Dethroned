using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurret;
	public TurretBlueprint missileLauncher;
	public TurretBlueprint laserBeamer;

	public GameObject[] outlines;

	private Outline priorSelection = null;

	private BuildManager buildManager;

	void Start ()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret ()
	{
		Debug.Log("Standard Turret Selected");
		buildManager.SelectTurretToBuild(standardTurret);
	}

	public void SelectMissileLauncher()
	{
		Debug.Log("Missile Launcher Selected");
		buildManager.SelectTurretToBuild(missileLauncher);
	}

	public void SelectLaserBeamer()
	{
		Debug.Log("Laser Beamer Selected");
		buildManager.SelectTurretToBuild(laserBeamer);
	}

	public void SelectWeapon(string turretType)
	{
		TurretBlueprint tb = null;

		switch (turretType)
		{
			case "StandardTurretItem":
				tb = standardTurret;
				break;
			case "MissileLauncherItem":
				tb = missileLauncher;
				break;
			case "LaserBeamerItem":
				tb = laserBeamer;
				break;
			default:
				break;
		}
		//outlines
		ChangeSelection(turretType);
		Debug.Log($"{turretType} Selected");
		buildManager.SelectTurretToBuild(tb);
	}

	public void ToggleSelection(string turretType)
	{
		foreach (GameObject go in outlines)
		{
			Outline outline = go.GetComponent<Outline>();
			if (outline)
			{
				outline.enabled = false;
			} 
			if (go.name.Contains(turretType))
			{
				outline.enabled = true;
			}
		}
	}

	public void ChangeSelection(string turretType)
	{
		foreach (GameObject go in outlines)
		{
			if (go.name == (turretType))
			{
				Outline outline = go.GetComponent<Outline>();

				if (priorSelection) priorSelection.enabled = false;
				outline.enabled = true;
				priorSelection = outline;
				return;
			}
		}
	}

}
