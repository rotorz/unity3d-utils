// Copyright (c) Rotorz Limited. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using UnityEditor;
using UnityEngine;

namespace Rotorz.Games.UnityEditorExtensions
{
    /// <summary>
    /// Extra styles for editor user interfaces.
    /// </summary>
    public sealed class ExtraEditorStyles : EditorSingletonScriptableObject
    {
        private static ExtraEditorStyles s_Instance;
        private static SkinInfo s_Skin;


        /// <summary>
        /// Gets the one-and-only <see cref="ExtraEditorStyles"/> instance.
        /// </summary>
        public static ExtraEditorStyles Instance {
            get {
                EditorSingletonUtility.GetAssetInstance<ExtraEditorStyles>(ref s_Instance);
                return s_Instance;
            }
        }

        /// <summary>
        /// Gets the current skin.
        /// </summary>
        public static SkinInfo Skin {
            get {
                if (s_Skin == null) {
                    s_Skin = EditorGUIUtility.isProSkin ? Instance.darkSkin : Instance.lightSkin;
                }
                return s_Skin;
            }
        }


        [SerializeField]
        private SkinInfo darkSkin = new SkinInfo();
        [SerializeField]
        private SkinInfo lightSkin = new SkinInfo();


        public GUIStyle BigButton { get; private set; }
        public GUIStyle BigButtonLeftAligned { get; private set; }
        public GUIStyle BigButtonRightAligned { get; private set; }
        public GUIStyle BigButtonExtraPadded { get; private set; }

        public GUIStyle WhiteWordWrappedMiniLabel { get; private set; }
        public GUIStyle BoldLabel { get; private set; }
        public GUIStyle RightAlignedMiniLabel { get; internal set; }
        public GUIStyle GroupLabel { get; private set; }

        public GUIStyle WhiteMetaLabel { get; private set; }
        public GUIStyle MetaLabel { get; private set; }
        public GUIStyle MetaLinkButton { get; private set; }

        public GUIStyle SearchTextField { get; private set; }
        public GUIStyle SearchCancelButton { get; private set; }
        public GUIStyle SearchCancelButtonEmpty { get; private set; }

        public GUIStyle ListItem { get; private set; }
        public GUIStyle ListItemActive { get; private set; }

        public GUIStyle Separator { get; private set; }


        /// <inheritdoc/>
        protected override void OnInitialize()
        {
            var skin = GUI.skin;
            var hiLabelStyle = skin.FindStyle("Hi Label");

            this.BigButton = new GUIStyle(skin.button);
            this.BigButton.padding = new RectOffset(26, 27, 10, 10);
            this.BigButton.richText = true;

            this.BigButtonLeftAligned = new GUIStyle(this.BigButton);
            this.BigButtonLeftAligned.alignment = TextAnchor.MiddleLeft;

            this.BigButtonRightAligned = new GUIStyle(this.BigButton);
            this.BigButtonRightAligned.alignment = TextAnchor.MiddleRight;

            this.BigButtonExtraPadded = new GUIStyle(this.BigButton);
            this.BigButtonExtraPadded.padding.left = 34;
            this.BigButtonExtraPadded.padding.right = 35;

            this.WhiteWordWrappedMiniLabel = new GUIStyle(EditorStyles.whiteMiniLabel);
            this.WhiteWordWrappedMiniLabel.wordWrap = true;

            this.BoldLabel = new GUIStyle(EditorStyles.label);
            this.BoldLabel.fontStyle = FontStyle.Bold;

            this.RightAlignedMiniLabel = new GUIStyle(EditorStyles.miniLabel);
            this.RightAlignedMiniLabel.alignment = TextAnchor.MiddleRight;

            this.GroupLabel = new GUIStyle();
            this.GroupLabel.fontSize = 20;
            this.GroupLabel.fontStyle = FontStyle.Normal;
            this.GroupLabel.normal.textColor = Skin.GroupLabelColor;
            this.GroupLabel.margin = new RectOffset(5, 5, 6, 1);

            this.WhiteMetaLabel = new GUIStyle();
            this.WhiteMetaLabel.fontSize = 11;
            this.WhiteMetaLabel.fontStyle = FontStyle.Normal;
            this.WhiteMetaLabel.normal.textColor = Color.white;
            this.WhiteMetaLabel.alignment = TextAnchor.UpperLeft;
            this.WhiteMetaLabel.clipping = TextClipping.Clip;
            this.WhiteMetaLabel.richText = true;

            this.MetaLabel = new GUIStyle(this.WhiteMetaLabel);
            this.MetaLabel.normal.textColor = Skin.MetaLabelColor;

            this.MetaLinkButton = new GUIStyle(this.MetaLabel);
            this.MetaLinkButton.normal.textColor = Color.white;
            this.MetaLinkButton.hover.textColor = Color.white;
            this.MetaLinkButton.hover.background = Skin.UnderlineBackground;
            this.MetaLinkButton.border = new RectOffset(0, 0, 1, 1);
            this.MetaLinkButton.fixedHeight = 14;
            this.MetaLinkButton.richText = true;

            this.SearchTextField = new GUIStyle(skin.FindStyle("SearchTextField"));
            this.SearchCancelButton = new GUIStyle(skin.FindStyle("SearchCancelButton"));
            this.SearchCancelButtonEmpty = new GUIStyle(skin.FindStyle("SearchCancelButtonEmpty"));

            this.ListItem = new GUIStyle(skin.label);
            this.ListItem.margin = new RectOffset();
            this.ListItem.padding = new RectOffset(5, 5, 0, 0);
            this.ListItem.alignment = TextAnchor.MiddleLeft;
            this.ListItem.onNormal.background = hiLabelStyle.onActive.background;
            this.ListItem.onNormal.textColor = Color.white;
            this.ListItem.fixedHeight = 25;

            this.ListItemActive = new GUIStyle(this.ListItem);
            this.ListItemActive.fontStyle = FontStyle.Bold;

            this.Separator = new GUIStyle();
            this.Separator.normal.background = EditorGUIUtility.whiteTexture;
            this.Separator.stretchWidth = true;
        }


        [System.Serializable]
        public sealed class SkinInfo
        {
            [SerializeField]
            private Color windowBackgroundColor = Color.black;
            [SerializeField]
            private Color separatorColor = Color.black;
            [SerializeField]
            private Color separatorLightColor = Color.black;
            [SerializeField]
            private Color groupLabelColor = Color.black;
            [SerializeField]
            private Color metaLabelColor = Color.black;
            [SerializeField]
            private Color linkColor = Color.black;
            [SerializeField]
            private Color selectedHighlightColor = Color.black;
            [SerializeField]
            private Color selectedHighlightStrongColor = Color.black;


            [SerializeField]
            private Texture2D underlineBackground = null;


            public Color WindowBackgroundColor {
                get { return this.windowBackgroundColor; }
            }

            public Color SeparatorColor {
                get { return this.separatorColor; }
            }

            public Color SeparatorLightColor {
                get { return this.separatorLightColor; }
            }

            public Color GroupLabelColor {
                get { return this.groupLabelColor; }
            }

            public Color MetaLabelColor {
                get { return this.metaLabelColor; }
            }

            public Color LinkColor {
                get { return this.linkColor; }
            }

            public Color SelectedHighlightColor {
                get { return this.selectedHighlightColor; }
            }

            public Color SelectedHighlightStrongColor {
                get { return this.selectedHighlightStrongColor; }
            }


            public Texture2D UnderlineBackground {
                get { return this.underlineBackground; }
            }
        }
    }
}
