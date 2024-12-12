namespace ASPNETMaker2024.Models;

// Partial class
public partial class project2 {
    /// <summary>
    /// login
    /// </summary>
    public static Login login
    {
        get => HttpData.Get<Login>("login")!;
        set => HttpData["login"] = value;
    }

    /// <summary>
    /// Page class (login)
    /// </summary>
    public class Login : LoginBase
    {
        // Constructor
        public Login(Controller controller) : base(controller)
        {
        }

        // Constructor
        public Login() : base()
        {
        }

        // Server events
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class LoginBase : Users
    {
        // Page ID
        public string PageID = "login";

        // Project ID
        public string ProjectID = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}";

        // Page object name
        public string PageObjName = "login";

        // Title
        public string? Title = null; // Title for <title> tag

        // Page headings
        public string Heading = "";

        public string Subheading = "";

        public string PageHeader = "";

        public string PageFooter = "";

        // Token
        public string? Token = null; // DN

        public bool CheckToken = Config.CheckToken;

        // Action result // DN
        public IActionResult? ActionResult;

        // Cache // DN
        public IMemoryCache? Cache;

        // Page layout
        public bool UseLayout = true;

        // Page terminated // DN
        private bool _terminated = false;

        // Is terminated
        public bool IsTerminated => _terminated;

        // Is lookup
        public bool IsLookup => IsApi() && RouteValues.TryGetValue("controller", out object? name) && SameText(name, Config.ApiLookupAction);

        // Is AutoFill
        public bool IsAutoFill => IsLookup && SameText(Post("ajax"), "autofill");

        // Is AutoSuggest
        public bool IsAutoSuggest => IsLookup && SameText(Post("ajax"), "autosuggest");

        // Is modal lookup
        public bool IsModalLookup => IsLookup && SameText(Post("ajax"), "modal");

        // Page URL
        private string _pageUrl = "";

        // Constructor
        public LoginBase()
        {
            // Initialize
            CurrentPage = this;

            // Language object
            Language = ResolveLanguage();

            // Table object (users)
            if (users == null || users is Users)
                users = this;
            users ??= this;

            // Start time
            StartTime = Environment.TickCount;

            // Debug message
            LoadDebugMessage();

            // Open connection
            Conn = Connection; // DN
        }

        // Page action result
        public IActionResult PageResult()
        {
            if (ActionResult != null)
                return ActionResult;
            SetupMenus();
            return Controller.View();
        }

        // Page heading
        public string PageHeading
        {
            get {
                if (!Empty(Heading))
                    return Heading;
                else
                    return "";
            }
        }

        // Page subheading
        public string PageSubheading
        {
            get {
                if (!Empty(Subheading))
                    return Subheading;
                return "";
            }
        }

        // Page name
        public string PageName => "login";

        // Page URL
        public string PageUrl
        {
            get {
                if (_pageUrl == "") {
                    _pageUrl = PageName + "?";
                }
                return _pageUrl;
            }
        }

        // Show Page Header
        public IHtmlContent ShowPageHeader()
        {
            string header = PageHeader;
            PageDataRendering(ref header);
            if (!Empty(header)) // Header exists, display
                return new HtmlString("<div id=\"ew-page-header\">" + header + "</div>");
            return HtmlString.Empty;
        }

        // Show Page Footer
        public IHtmlContent ShowPageFooter()
        {
            string footer = PageFooter;
            PageDataRendered(ref footer);
            if (!Empty(footer)) // Footer exists, display
                return new HtmlString("<div id=\"ew-page-footer\">" + footer + "</div>");
            return HtmlString.Empty;
        }

        // Valid post
        protected async Task<bool> ValidPost() => !CheckToken || !IsPost() || IsApi() || Antiforgery != null && HttpContext != null && await Antiforgery.IsRequestValidAsync(HttpContext);

        // Create token
        public void CreateToken()
        {
            Token ??= HttpContext != null ? Antiforgery?.GetAndStoreTokens(HttpContext).RequestToken : null;
            CurrentToken = Token ?? ""; // Save to global variable
        }

        // Constructor
        public LoginBase(Controller? controller = null): this() { // DN
            if (controller != null)
                Controller = controller;
        }

        /// <summary>
        /// Terminate page
        /// </summary>
        /// <param name="url">URL to rediect to</param>
        /// <returns>Page result</returns>
        public override IActionResult Terminate(string url = "") { // DN
            if (_terminated) // DN
                return new EmptyResult();

            // Page Unload event
            PageUnload();

            // Global Page Unloaded event
            PageUnloaded();
            PageUnloadedEventHandler?.Invoke(this, EventArgs.Empty);
            if (!IsApi())
                PageRedirecting(ref url);

            // Gargage collection
            Collect(); // DN

            // Terminate
            _terminated = true; // DN

            // Return for API
            if (IsApi()) {
                var result = new Dictionary<string, string> { { "version", Config.ProductVersion } };
                if (!Empty(url)) // Add url
                    result.Add("url", GetUrl(url));
                foreach (var (key, value) in GetMessages()) // Add messages
                    result.Add(key, value);
                return Controller.Json(result);
            } else if (ActionResult != null) { // Check action result
                return ActionResult;
            }

            // Go to URL if specified
            if (!Empty(url)) {
                if (!Config.Debug)
                    ResponseClear();
                if (Response != null && !Response.HasStarted) {
                    // Handle modal response
                    if (IsModal) { // Show as modal
                        var result = new { url = GetUrl(url) };
                        return Controller.Json(result);
                    } else {
                        SaveDebugMessage();
                        return Controller.LocalRedirect(AppPath(url));
                    }
                }
            }
            return new EmptyResult();
        }

        // Username/Password/LoginType field object (used by validation only)
        public DbField<MySqlDbType> LoginUsername = new("users", "username", 202, MySqlDbType.VarString) {
                TableName = "users",
                Name = "username",
                Expression = "username"
            }; // DN

        public DbField<MySqlDbType> LoginPassword = new("users", "password", 202, MySqlDbType.VarString) {
                TableName = "users",
                Name = "password",
                Expression = "password"
            }; // DN

        public DbField<MySqlDbType> LoginType = new("users", "type", 202, MySqlDbType.VarString) {
                TableName = "users",
                Name = "logintype",
                Expression = "logintype"
            };
        // Properties
        public bool IsModal = false;

        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            OffsetColumnClass = ""; // Override user table
            LoginUsername.EditAttrs.AppendClass("form-control ew-form-control");
            LoginPassword.EditAttrs.AppendClass("form-control ew-form-control");
            if (Config.EncryptedPassword)
                LoginPassword.Raw = true;

            // Is modal
            IsModal = Param<bool>("modal");
            UseLayout = UseLayout && !IsModal;

            // Use layout
            if (!Empty(Param("layout")) && !Param<bool>("layout"))
                UseLayout = false;

            // User profile
            Profile = ResolveProfile();

            // Security
            Security = ResolveSecurity();

            // Load user profile
            if (IsLoggedIn()) {
                await Profile.SetUserName(CurrentUserName()).LoadFromStorageAsync();
            }
            CurrentAction = Param("action"); // Set up current action

            // Global Page Loading event
            PageLoading();
            PageLoadingEventHandler?.Invoke(this, EventArgs.Empty);

            // Page Load event
            PageLoad();

            // Check token
            if (!await ValidPost())
                End(Language.Phrase("InvalidPostRequest"));

            // Check action result
            if (ActionResult != null) // Action result set by server event // DN
                return ActionResult;

            // Create token
            CreateToken();

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;
            CurrentBreadcrumb = new();
            var url = CurrentUrl(); // DN
            CurrentBreadcrumb.Add("login", "LoginPage", url, "", "", true);
            Heading = Language.Phrase("LoginPage");
            bool validate = false, validPassword = false;
            LoginUsername.SetFormValue(""); // Initialize
            LoginPassword.SetFormValue("");
            LoginType.SetFormValue("");
            var model = new LoginModel();
            string lastUrl = Security.LastUrl; // Get last URL
            if (Empty(lastUrl))
                lastUrl = "index";

            // Show messages
            if (TempData["heading"] != null)
                MessageHeading = ConvertToString(TempData["heading"]);
            if (TempData["failure"] != null)
                FailureMessage = ConvertToString(TempData["failure"]);
            if (TempData["success"] != null)
                SuccessMessage = ConvertToString(TempData["success"]);
            if (TempData["warning"] != null)
                WarningMessage = ConvertToString(TempData["warning"]);

            // Login
            string provider = RouteValues["provider"] != null ? ConvertToString(RouteValues["provider"]) : Get("provider"); // e.g. Google, Facebook, Azure, Saml
            if (IsLoggingIn()) { // After changing password
                LoginUsername.SetFormValue(Session.GetString(Config.SessionUserProfileUserName));
                LoginPassword.SetFormValue(Session.GetString(Config.SessionUserProfilePassword));
                LoginType.SetFormValue(Session.GetString(Config.SessionUserProfileLoginType));
                model.Username = ConvertToString(LoginUsername.CurrentValue);
                model.Password = ConvertToString(LoginPassword.CurrentValue);
                validPassword = await Security.ValidateUser(model);
                if (validPassword) {
                    Session[Config.SessionUserProfileUserName] = "";
                    Session[Config.SessionUserProfilePassword] = "";
                    Session[Config.SessionUserProfileLoginType] = "";
                    Security.RemoveLastUrl();
                    return Terminate(lastUrl); // Redirect to last page
                }
            } else if (Config.UseTwoFactorAuthentication && IsLoggingIn2FA()) { // Logging in via 2FA, redirect
                return Terminate("login2fa");
            } else { // Normal login
                if (!Security.IsLoggedIn)
                    await Security.AutoLoginAsync();
                Security.LoadUserLevel(); // Load user level
                if (Security.IsLoggedIn) {
                    Security.RemoveLastUrl();
                    if (Empty(FailureMessage))
                        return Terminate(lastUrl); // Return to last accessed page
                }
                StringValues sv;

                // Setup variables
                if (Post(LoginUsername.FieldVar, out sv)) {
                    LoginUsername.SetFormValue(sv);
                    LoginPassword.SetFormValue(Post(LoginPassword.FieldVar));
                    LoginType.SetFormValue(Post(LoginType.FieldVar));
                    validate = await ValidateForm();
                } else if (Config.AllowLoginByUrl && Get(LoginUsername.FieldVar, out sv)) {
                    LoginUsername.SetQueryValue(sv);
                    LoginPassword.SetQueryValue(Get(LoginPassword.FieldVar));
                    LoginType.SetQueryValue(Get(LoginType.FieldVar));
                    validate = await ValidateForm();
                } else { // Restore settings
                    string jwt = Cookie["AutoLogin"]; // DN
                    if (!Empty(jwt)) {
                        Dictionary<string, string> values = DecodeJwt(jwt);
                        LoginUsername.SetFormValue(values.ContainsKey("Username") ? values["Username"] : "");
                        LoginType.SetFormValue("a");
                    }
                }
                if (!Empty(LoginUsername.CurrentValue)) {
                    Session[Config.SessionUserLoginType] = ConvertToString(LoginType.CurrentValue); // Save user login type
                    Session[Config.SessionUserProfileUserName] = ConvertToString(LoginUsername.CurrentValue); // Save login user name
                    Session[Config.SessionUserProfileLoginType] = ConvertToString(LoginType.CurrentValue); // Save login type
                }
                validPassword = false;
                if (validate) {
                    model.Username = ConvertToString(LoginUsername.CurrentValue);
                    model.Password = ConvertToString(LoginPassword.CurrentValue);

                    // Call Logging In event
                    validate = UserLoggingIn(model.Username, model.Password);
                    if (validate) {
                        validPassword = await Security.ValidateUser(model); // Manual login
                        if (!validPassword) {
                            LoginUsername.SetFormValue(""); // Clear login name
                            LoginUsername.AddErrorMessage(Language.Phrase("InvalidUidPwd")); // Invalid user name or password
                            LoginPassword.AddErrorMessage(Language.Phrase("InvalidUidPwd")); // Invalid user name or password
                        }

                        // Two factor authentication enabled
                        bool sendOtp = (new [] { "email", "sms" }).Contains(Config.TwoFactorAuthenticationType.ToLowerInvariant());
                        if (validPassword &&
                            (!IsSysAdmin() || Config.OtpOnly && sendOtp && !Empty(Config.AdminOtpAccount)) && // Non-Admin or Admin + Disable password checking + send OTP
                            Config.UseTwoFactorAuthentication &&
                            (Config.ForceTwoFactorAuthentication || Profile.HasUserSecret(true))
                        ) {
                            JsonBoolResult result = new(new { success = true, version = Config.ProductVersion }, true);
                            if (sendOtp) { // Send one time password if verified
                                Session.SetValue(Config.SessionUserProfileRecord, IsSysAdmin() // System admin, use session for profile field
                                    ? (Config.TwoFactorAuthenticationType.ToLowerInvariant() == "email"
                                        ? new Dictionary<string, object> { { Config.SysAdminEmailAddress, Config.AdminOtpAccount } }
                                        : new Dictionary<string, object> { { Config.SysAdminPhoneNumber, Config.AdminOtpAccount } })
                                    : "");
                                result = await Current2FA.SendOneTimePassword(model.Username);
                            }
                            if (result) { // Go to 2FA page
                                Session[Config.SessionStatus] = "loggingin2fa";
                                Session[Config.SessionUserProfileUserName] = model.Username;
                                Session[Config.SessionUserProfilePassword] = model.Password;
                                Session[Config.SessionUserProfileLoginType] = LoginType.CurrentValue;
                                IsModal = false; // Redirect
                                return Terminate("login2fa?" + Config.PageLayout + "=false");
                            } else {
                                FailureMessage = ClientSendError; // DN
                                Security.LogoutUser(); // Logout user
                                validPassword = false; // Handle as invalid password
                            }
                        }
                    } else {
                        if (Empty(FailureMessage))
                            FailureMessage = Language.Phrase("LoginCancelled"); // Login cancelled
                    }
                }
            }

            // After login
            if (validPassword) {
                if (SameText(LoginType.CurrentValue, "a")) { // Auto login
                    Cookie["AutoLogin"] = CreateJwt(new Dictionary<string, object?>
                        {
                            { "Username", model.Username },
                            { "autologin", "true" }
                        }, Config.RememberMeExpiryTime); // Write cookie
                } else {
                    Cookie.Remove("AutoLogin"); // Clear autologin cookies
                }

                // Call loggedin event
                UserLoggedIn(model.Username);

                // OAuth provider, just redirect
                if (!Empty(provider))
                    IsModal = false;
                // Two factor authentication enabled (login directly), return JSON
                else if (Config.UseTwoFactorAuthentication)
                    IsModal = true;
                Security.RemoveLastUrl();
                return Terminate(lastUrl); // Return to last accessed URL
            } else if (!Empty(model.Username) && !Empty(model.Password)) {
                // Call user login error event
                UserLoginError(model.Username, model.Password);
            }

            // Set up error message
            if (Empty(LoginUsername.ErrorMessage))
                LoginUsername.ErrorMessage = Language.Phrase("EnterUserName");
            if (Empty(LoginPassword.ErrorMessage))
                LoginPassword.ErrorMessage = Language.Phrase("EnterPassword");

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);
            }
            return PageResult();
        }

        #pragma warning disable 1998
        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
            if (Empty(LoginUsername.CurrentValue)) {
                LoginUsername.AddErrorMessage(Language.Phrase("EnterUserName"));
                validateForm = false;
            }
            if (Empty(LoginPassword.CurrentValue) && !Config.OtpOnly) { // Ignore if password checking disabled
                LoginPassword.AddErrorMessage(Language.Phrase("EnterPassword"));
                validateForm = false;
            }
            string formCustomError = "";
            validateForm = validateForm && FormCustomValidate(ref formCustomError);
            if (!Empty(formCustomError))
                FailureMessage = formCustomError;
            return validateForm;
        }
        #pragma warning restore 1998

        // Page Load event
        public virtual void PageLoad() {
            //Log("Page Load");
        }

        // Page Unload event
        public virtual void PageUnload() {
            //Log("Page Unload");
        }

        // Page Redirecting event
        public virtual void PageRedirecting(ref string url) {
            //url = newurl;
        }

        // Message Showing event
        // type = ""|"success"|"failure"|"warning"
        public virtual void MessageShowing(ref string msg, string type) {
            // Note: Do not change msg outside the following 4 cases.
            if (type == "success") {
                //msg = "your success message";
            } else if (type == "failure") {
                //msg = "your failure message";
            } else if (type == "warning") {
                //msg = "your warning message";
            } else {
                //msg = "your message";
            }
        }

        // Page Load event
        public virtual void PageRender() {
            //Log("Page Render");
        }

        // Page Data Rendering event
        public virtual void PageDataRendering(ref string header) {
            // Example:
            //header = "your header";
        }

        // Page Data Rendered event
        public virtual void PageDataRendered(ref string footer) {
            // Example:
            //footer = "your footer";
        }

        // User Logging In event
        public virtual bool UserLoggingIn(string usr, string pwd) {
            // Enter your code here
            // To cancel, set return value to False
            return true;
        }

        // User Logged In event
        public virtual void UserLoggedIn(string usr) {
            //Log("User Logged In");
        }

        // User Login Error event
        public virtual void UserLoginError(string usr, string pwd) {
            //Log("User Login Error");
        }

        // Form Custom Validate event
        public virtual bool FormCustomValidate(ref string customError) {
            //Return error message in customError
            return true;
        }
    } // End page class
} // End Partial class
