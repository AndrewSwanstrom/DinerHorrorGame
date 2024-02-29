using UnityEngine;
using UnityEngine.UI;

public class ToggleModes : MonoBehaviour
{
    public Toggle easyModeToggle;      // Toggle for Easy Mode
    public Toggle hardModeToggle;      // Toggle for Hard Mode
    public Image Easymodeicon;
    public Image Hardmodeicon;
    public GameObject HardModeWater;
    public GameObject NormalModeWater;
    public GameObject EasyModeWater;

    private void Start()
    {
        // Load the saved toggle state and alpha values
        LoadToggleState();
        LoadIconAlphaValues();

        // Set up object states based on the loaded toggle values
        UpdateObjectStates();

        // Checks if toggled
        easyModeToggle.onValueChanged.AddListener(OnEasyModeToggleValueChanged);
        hardModeToggle.onValueChanged.AddListener(OnHardModeToggleValueChanged);
    }

    private void LoadToggleState()
    {
        // Load the state of easyModeToggle and hardModeToggle from PlayerPrefs
        easyModeToggle.isOn = PlayerPrefs.GetInt("EasyModeToggle", 0) == 1;
        hardModeToggle.isOn = PlayerPrefs.GetInt("HardModeToggle", 0) == 1;
    }

    private void LoadIconAlphaValues()
    {
        // Load the alpha values of icons from PlayerPrefs
        float easymodeAlpha = PlayerPrefs.GetFloat("EasymodeAlpha", 0.0f);
        float hardmodeAlpha = PlayerPrefs.GetFloat("HardmodeAlpha", 0.0f);

        // Set the alpha values
        ChangeAlpha(Easymodeicon, easymodeAlpha);
        ChangeAlpha(Hardmodeicon, hardmodeAlpha);
    }

    private void OnEasyModeToggleValueChanged(bool isEasyMode)
    {
        // Save the state of easyModeToggle to PlayerPrefs
        PlayerPrefs.SetInt("EasyModeToggle", isEasyMode ? 1 : 0);
        PlayerPrefs.Save();

        if (isEasyMode)
        {
            // Set alpha to 1 when easy mode is turned on
            ChangeAlpha(Easymodeicon, 1.0f);
            ChangeAlpha(Hardmodeicon, 0.0f);
            hardModeToggle.isOn = false; // Turn off hard mode toggle
        }
        else
        {
            // If easy mode is turned off, set alpha to 0
            ChangeAlpha(Easymodeicon, 0.0f);
        }

        // Save the alpha value of Easymodeicon to PlayerPrefs
        PlayerPrefs.SetFloat("EasymodeAlpha", Easymodeicon.color.a);
        PlayerPrefs.Save();

        // Update object states
        UpdateObjectStates();
    }

    private void OnHardModeToggleValueChanged(bool isHardMode)
    {
        // Save the state of hardModeToggle to PlayerPrefs
        PlayerPrefs.SetInt("HardModeToggle", isHardMode ? 1 : 0);
        PlayerPrefs.Save();

        if (isHardMode)
        {
            // Set alpha to 1 when hard mode is turned on
            ChangeAlpha(Hardmodeicon, 1.0f);
            ChangeAlpha(Easymodeicon, 0.0f);
            easyModeToggle.isOn = false; // Turn off easy mode toggle
        }
        else
        {
            // If hard mode is turned off, set alpha to 0
            ChangeAlpha(Hardmodeicon, 0.0f);
        }

        // Save the alpha value of Hardmodeicon to PlayerPrefs
        PlayerPrefs.SetFloat("HardmodeAlpha", Hardmodeicon.color.a);
        PlayerPrefs.Save();

        // Update object states
        UpdateObjectStates();
    }

    private void ChangeAlpha(Image icon, float alphaValue)
    {
        // Set the alpha value
        icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, alphaValue);
    }

    private void UpdateObjectStates()
    {
        // Set up object states based on the toggle values
        EasyModeWater.SetActive(easyModeToggle.isOn);
        HardModeWater.SetActive(hardModeToggle.isOn);

        // Disable NormalModeWater if either easy mode or hard mode is turned on
        NormalModeWater.SetActive(!(easyModeToggle.isOn || hardModeToggle.isOn));
    }

}
